using AutoMapper;
using BALK_Ticaret.Models;
using BLL.AbstractServices;
using BLL.ConcreteServices;
using BLL.Dtos;
using DAL.Entites;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace BALK_Ticaret.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IProductDetailService _productDetailService;
        private readonly IMapper _mapper;
        private readonly ICategoryService _categoryService;
        private readonly ILocationService _locationService;
        private readonly IWebHostEnvironment _environment;
        private readonly IProductLikeService _productLikeService;

        public ProductController(IProductService productService, IProductDetailService productDetailService, IMapper mapper, ICategoryService categoryService, ILocationService locationService, IWebHostEnvironment environment, IProductLikeService productLikeService)
        {
            _productService = productService;
            _productDetailService = productDetailService;
            _mapper = mapper;
            _categoryService = categoryService;
            _locationService = locationService;
            _environment = environment;
            _productLikeService = productLikeService;
        }
        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetAllProductWithDetail();

            if (products.Count > 0)
            {
                return View(_mapper.Map<List<ProductViewModel>>(products));

            }
            return View();

        }
        public async Task<IActionResult> Create()
        {
            var categories = await _categoryService.GetAllCategory();
            ViewBag.Categories = _mapper.Map<List<CategoryViewModel>>(categories);
            var countries = await _locationService.GetAllCountry();
            ViewBag.Countries = _mapper.Map<List<CountryViewModel>>(countries);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductViewModel product)
        {
            if (product.PhotoUrls != null && product.PhotoUrls.Count > 0)
            {
                var uploadsFolder = Path.Combine(_environment.WebRootPath, "img");

                foreach (var photo in product.PhotoUrls)
                {
                    if (photo.Length > 0)
                    {
                        var fileName = Path.GetFileName(photo.FileName);
                        var filePath = Path.Combine(uploadsFolder, fileName);

                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await photo.CopyToAsync(stream);
                        }

                        // Dosya kaydedildikten sonra, URL'sini Photos listesine ekleyin
                        product.Photos ??= new List<string>();
                        product.Photos.Add("/img/" + fileName);
                    }
                }

            }
            else
            {
                product.Photos = new List<string>();
                product.Photos[0] = "defaultProduct.jpg";
            }
            if (product.ProductDetail != null)
            {
                var productDetailDto = _mapper.Map<ProductDetailDto>(product.ProductDetail);
                await _productDetailService.CreateProductDetail(productDetailDto);
            }
            var allProductDetail = await _productDetailService.GetProductDetailAll();
            var newestProductDetail = allProductDetail.OrderByDescending(x => x.Id).FirstOrDefault();
            product.ProductDetailId = newestProductDetail != null ? newestProductDetail.Id : 0;
            if (product.CategoryId == 1)
            {
                product.Code = product?.ProductDetail?.CountryId.ToString() + product?.ProductDetail?.CityId.ToString() + product?.ProductDetail?.DistrictId.ToString() + product?.ProductDetail?.NeighborhoodId.ToString() + product?.Ada.ToString() + product?.Parcel.ToString();

            }
            else if (product.CategoryId == 2)
            {
                product.Code = product?.ProductDetail?.CountryId.ToString() + product?.ProductDetail?.CityId.ToString() + product?.ProductDetail?.DistrictId.ToString() + product?.ProductDetail?.NeighborhoodId.ToString() + product?.Ada.ToString() + product?.Parcel.ToString() + "K" + product?.ProductDetail?.Apartmennt + product?.ProductDetail?.DaireNo; ;
            }
            else if (product.CategoryId == 3)
            {
                product.Code = product?.ProductDetail?.CountryId.ToString() + product?.ProductDetail?.CityId.ToString() + product?.ProductDetail?.DistrictId.ToString() + product?.ProductDetail?.NeighborhoodId.ToString() + product?.Ada.ToString() + product?.Parcel.ToString() + "I" + product?.ProductDetail?.Apartmennt + product?.ProductDetail?.DaireNo;
            }
            await _productService.CreateProduct(_mapper.Map<ProductDto>(product));

            return RedirectToAction("Index", "Product");

        }

        public async Task<IActionResult> Detail(int productId)
        {
            var product = await _productService.GetProductWithDetail(productId);

            return View(_mapper.Map<ProductViewModel>(product));
        }
        [HttpPost]
        public async Task<IActionResult> LikeProduct(int productId, int userId)
        {
            await _productLikeService.HasLikeByUserOnProduct(productId, userId);
            return RedirectToAction("index", "Home");
        }

        public async Task<IActionResult> Update(int productId)
        {
            var product = await _productService.GetProductWithDetail(productId);
            ViewBag.Categories = await _categoryService.GetAllCategory();
            ViewBag.Countries = await _locationService.GetAllCountry();
            ViewBag.Cities = await _locationService.GetAllCity();
            ViewBag.District = await _locationService.GetAllDistrict();
            ViewBag.Neighborhood = await _locationService.GetAllNeighborhood();
            return View(_mapper.Map<ProductViewModel>(product));
        }
        [HttpPost]
        public async Task<IActionResult> Update(ProductViewModel product)
        {
            var updateProduct = await _productService.GetProductWithDetail(product.Id);
            // Eğer fotoğraflar varsa, fotoğrafları kaydedin
            if (product.PhotoUrls != null && product.PhotoUrls.Count > 0)
            {
                var uploadsFolder = Path.Combine(_environment.WebRootPath, "img");

                // Eski fotoğrafları silmek isteyebilirsiniz (gerekirse ekleyebilirsiniz)
                if (product.Photos != null)
                {
                    foreach (var oldPhoto in product.Photos)
                    {
                        var oldFilePath = Path.Combine(_environment.WebRootPath, oldPhoto.TrimStart('/'));
                        if (System.IO.File.Exists(oldFilePath))
                        {
                            System.IO.File.Delete(oldFilePath); // Eski fotoğrafları sil
                        }
                    }
                }

                // Fotoğrafları kaydet ve listeye ekle
                product.Photos = new List<string>();

                foreach (var photo in product.PhotoUrls)
                {
                    if (photo.Length > 0)
                    {
                        var fileName = Path.GetFileName(photo.FileName);
                        var filePath = Path.Combine(uploadsFolder, fileName);

                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await photo.CopyToAsync(stream); // Fotoğrafı kaydet
                        }

                        // Fotoğrafın URL'sini ekle
                        product.Photos.Add("/img/" + fileName);
                    }
                }
            }
            else
            {
                // Eğer hiç fotoğraf yüklenmemişse, varsayılan fotoğrafı ekle
                product.Photos = updateProduct.Photos;
            }

            if (product != null)
            {
                if (product.ProductDetail != null)
                {
                    await _productDetailService.UpdateProductDetail(_mapper.Map<ProductDetailDto>(product.ProductDetail));
                }
            }


            await _productService.UpdateProduct(_mapper.Map<ProductDto>(product));


            return RedirectToAction("Index", "Product");
        }

        public async Task<IActionResult> UsersLikes()
        {
            var products = new List<ProductDto>();
            var userId = (HttpContext.Session.GetInt32("UserId")).Value;
            var usersLikes = await _productLikeService.GetLikeByUserId(userId);
            var userLikesView=_mapper.Map<List<ProductLikeViewModel>>(usersLikes);
            if (usersLikes != null)
            {
                foreach (var user in userLikesView)
                {
                    var product = await _productService.GetProductId(user.ProductId);
                    if (product != null)
                    {
                        products.Add(product);
                    }
                }
            }
            return View(_mapper.Map<List<ProductViewModel>>(products));

        }

    }
}
