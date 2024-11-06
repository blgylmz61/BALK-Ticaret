using AutoMapper;
using BALK_Ticaret.Models;
using BLL.AbstractServices;
using BLL.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace BALK_Ticaret.Controllers
{
    public class GenderController : Controller
    {
        private readonly IGenderService _genderService;
        private readonly IMapper _mapper;

        public GenderController(IGenderService genderService, IMapper mapper)
        {
            _genderService = genderService;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var allGenders = await _genderService.GetAllGender();
            if (allGenders != null)
            {
                return View(_mapper.Map<List<GenderViewModel>>(allGenders));
            }
            return View();
        }

        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(GenderViewModel genderViewModel)
        {
            if (genderViewModel != null)
            {
                var genderDto = _mapper.Map<GenderDto>(genderViewModel);
                await _genderService.CreateGender(genderDto);
                return RedirectToAction("Index", "Gender");
            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int genderId)
        {
            await _genderService.DeleteGender(genderId);
            return RedirectToAction("Index", "Gender");
        }
        public async Task<IActionResult> Update(int genderId)
        {
            var Gender = await _genderService.GetGenderById(genderId);

            return View(_mapper.Map<GenderViewModel>(Gender));
        }
        [HttpPost]
        public async Task<IActionResult> Update(GenderViewModel GenderViewModel, int genderId)
        {
            var Gender = await _genderService.GetGenderById(genderId);
            Gender.Name = GenderViewModel.Name;
            await _genderService.UpdateGender(_mapper.Map<GenderDto>(Gender));

            return RedirectToAction("Index", "Gender");

        }
    }
}

