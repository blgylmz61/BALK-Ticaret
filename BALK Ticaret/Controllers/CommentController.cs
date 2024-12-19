using AutoMapper;
using BALK_Ticaret.Models;
using BLL.AbstractServices;
using BLL.Dtos;
using DAL.AbstractRepository;
using DAL.Entites;
using Microsoft.AspNetCore.Mvc;

namespace BALK_Ticaret.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public CommentController(ICommentService commentService, IMapper mapper,IUserService userService)
        {
            _commentService = commentService;
            _mapper = mapper;
            _userService = userService;
        }
        public IActionResult Index()
        {
            
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(CommentViewModel commentView,int userId, int productId,int Scrol)
        {
           
            commentView.UserId = userId;
            commentView.ProductId = productId;
            commentView.CommentDate = DateTime.Now;
            commentView.Scor = Scrol;
            if (commentView != null)
            {
                var commentDto = _mapper.Map<CommentDto>(commentView);
                await _commentService.CreateComment(commentDto);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();

            }


        }
    }
}
