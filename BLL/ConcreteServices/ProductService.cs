using AutoMapper;
using BLL.AbstractServices;
using BLL.Dtos;
using BLL.Helpers;
using DAL.AbstractRepository;
using DAL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ConcreteServices
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _productRepository;
        private readonly IMapper _mapper;
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<ProductLike> _productLikeRepository;

        public ProductService(IRepository<Product> productRepository, IMapper mapper,IRepository<User> userRepository,IRepository<ProductLike> productLikeRepository)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _userRepository = userRepository;
            _productLikeRepository = productLikeRepository;
        }
        public async Task<bool> CheckProduct(string productcode)
        {
            if (productcode != null)
            {
                var products = await _productRepository.FindAsync(x => x.Code == productcode);
                if (products != null) { return true; }
            }
            return false;
        }

        public async Task CreateProduct(ProductDto productDto)
        {
            productDto.Name = StringHelper.CapitalizeFirstLetterOfEachWord(productDto.Name);
            await _productRepository.AddAsync(_mapper.Map<Product>(productDto));

        }

        public async Task DeleteProduct(int productId)
        {
            await _productRepository.DeleteAsync(productId);
        }

        public async Task<List<ProductDto>> GetAllProducts()
        {
            var products = await _productRepository.GetAllAsync();
            

            return (_mapper.Map<List<ProductDto>>(products));
        }

        public async Task<ProductDto> GetProductId(int productId)
        {
            var product = await _productRepository.GetByIdAsync(productId);
            return _mapper.Map<ProductDto>(product);

        }

        public async Task<IEnumerable<ProductDto>> GetProductConditionAsync(Expression<Func<ProductDto, bool>> predicate)
        {
            var productPredicate = _mapper.Map<Expression<Func<Product, bool>>>(predicate);
            var products = await _productRepository.FindAsync(productPredicate);
            return (_mapper.Map<IEnumerable<ProductDto>>(products));
        }

        public Task<List<ProductDto>> Search(string searchedTerm)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateProduct(ProductDto productDto)
        {
            var product = await _productRepository.GetByIdAsync(productDto.Id);
            if (product == null)
            {
                throw new Exception("Ürün bulunamadı");
            }
            product.Name = StringHelper.CapitalizeFirstLetterOfEachWord(productDto.Name);
            product.Photos = productDto.Photos;
            product.Description = productDto.Description;
            product.UnitPriceM2 = productDto.UnitPriceM2;
            product.M2 = productDto.M2;
            product.Ada = productDto.Ada;
            product.Parcel = productDto.Parcel;
            product.CategoryId = productDto.CategoryId;
            product.ProductDetailId = productDto.ProductDetailId;
            await _productRepository.UpdateAsync(product);

        }

        public async Task<ProductDto> GetProductWithDetail(int productId)
        {
            var product = await _productRepository.GetWithIncludeAsync(
                x => x.Id == productId,
               p => p.ProductDetail,
                 p => p.Category,
                 p => p.ProductDetail.Country,
                 p => p.ProductDetail.City,
                 p => p.ProductDetail.District,
                 p => p.ProductDetail.Neighborhood);
            
            return (_mapper.Map<ProductDto>(product));
        }

        public async Task<List<ProductDto>> GetAllProductWithDetail()
        {
            var products = await _productRepository.GetAllWithIncludeAsync(x => true,
               p => p.ProductDetail,
                 p => p.Category,
                 p => p.ProductDetail.Country,
                 p => p.ProductDetail.City,
                 p => p.ProductDetail.District,
                 p => p.ProductDetail.Neighborhood);
            foreach (var product in products)
            {
                product.Name = StringHelper.CapitalizeFirstLetterOfEachWord(product.Name);
                product.ProductDetail.Neighborhood.Name = StringHelper.CapitalizeFirstLetterOfEachWord(product.ProductDetail.Neighborhood.Name);
                product.ProductDetail.Neighborhood.District.Name = StringHelper.CapitalizeFirstLetterOfEachWord(product.ProductDetail.Neighborhood.District.Name);
                product.ProductDetail.Neighborhood.District.City.Name = StringHelper.CapitalizeFirstLetterOfEachWord(product.ProductDetail.Neighborhood.District.City.Name);
                product.ProductDetail.Neighborhood.District.City.Country.Name = StringHelper.CapitalizeFirstLetterOfEachWord(product.ProductDetail.Neighborhood.District.City.Country.Name);
                product.Description = StringHelper.CapitalizeFirstLetterOfEachWord(product?.Description);

            }
            return (_mapper.Map<List<ProductDto>>(products));
        }

       
    }
}
