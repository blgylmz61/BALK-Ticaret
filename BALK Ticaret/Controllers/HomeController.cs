using AutoMapper;
using BALK_Ticaret.Models;
using BLL.AbstractServices;
using BLL.ConcreteServices;
using DAL.Entites;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace BALK_Ticaret.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        private readonly IProductLikeService _productLikeService;
        private readonly ICommentService _commentService;

        public HomeController(ILogger<HomeController> logger, IProductService productService, IMapper mapper, IProductLikeService productLikeService,ICommentService commentService)
        {
            _logger = logger;
            _productService = productService;
            _mapper = mapper;
            _productLikeService = productLikeService;
            _commentService = commentService;
        }

        public async Task<IActionResult> Index()
        {
            var comments = await _commentService.GetAllComment();
            ViewBag.Comments = _mapper.Map<List<CommentViewModel>>(comments);
         
            var products = await _productService.GetAllProductWithDetail();
            var likedProducts = await _productLikeService.GetAllLike();
            ViewBag.LikedProducts = _mapper.Map<List<ProductLikeViewModel>>(likedProducts);
            TempData.Keep("PhotoUrl");



            return View(_mapper.Map<List<ProductViewModel>>(products));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
