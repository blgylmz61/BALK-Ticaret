using AutoMapper;
using BALK_Ticaret.Models;
using BLL.AbstractServices;
using BLL.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace BALK_Ticaret.Controllers
{
    public class CardController : Controller
    {
        private readonly ICardService _cardService;
        private readonly IMapper _mapper;

        public CardController(ICardService cardService, IMapper mapper)
        {
            _cardService = cardService;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create(int userId)
        {
            ViewBag.UserId = userId;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CardViewModel cardViewModel,int userId)
        {
            if (cardViewModel != null) { 
                cardViewModel.UserId = userId;
                var cardDto=_mapper.Map<CardDto>(cardViewModel);
                await _cardService.CreateCard(cardDto);
                return RedirectToAction("Profile", "Account");
            }
            else
            {
                return View();
            }
            
        }

    }
}
