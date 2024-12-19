using AutoMapper;
using BALK_Ticaret.Models;
using BLL.AbstractServices;
using BLL.ConcreteServices;
using BLL.Dtos;
using DAL.AbstractRepository;
using DAL.Entites;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BALK_Ticaret.Controllers
{
    public class UserController : Controller
    {
        private readonly ILocationService _locationService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly IUserDetailService _userDetailService;
        private readonly IUserRoleService _userRoleService;
        private readonly IGenderService _genderService;

        public UserController(ILocationService locationService, IUserService userService, IMapper mapper, IUserDetailService userDetailService, IUserRoleService userRoleService, IGenderService genderService)
        {
            _locationService = locationService;
            _userService = userService;
            _mapper = mapper;
            _userDetailService = userDetailService;
            _userRoleService = userRoleService;
            _genderService = genderService;
        }
        public async Task<IActionResult> Index()
        {

            var users = await _userService.GetAllUserWithDetail();
            return View(_mapper.Map<List<UserViewModel>>(users));
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int userId)
        {
            var user = await _userService.GetUserId(userId);
            await _userDetailService.DeleteUserDetail(user.UserDetailId);
            await _userService.DeleteUser(userId);
            if(user.UserRoleId == 1)
            {
                return RedirectToAction("Index", "User");

            }
            return RedirectToAction("Logout", "Account");
        }
        
        public async Task<IActionResult> Update(int userId)
        {
            var user = await _userService.GetUserWithDetail(userId);
         
            ViewBag.DistrictId = user.UserDetail?.DistrictId ?? null;
            var userRoles = await _userRoleService.GetUserRoleAll();
            if (userRoles != null)
            {
                ViewBag.UserRoles = _mapper.Map<List<UserRoleViewModel>>(userRoles);
            }
            var genders = await _genderService.GetAllGender();
            if (genders != null)
            {
                ViewBag.Genders = _mapper.Map<List<GenderViewModel>>(genders);
            }
            var allCountries = await _locationService.GetAllCountry();
            if (allCountries != null)
            {
                ViewBag.Countries = _mapper.Map<List<CountryViewModel>>(allCountries);
            }
            var allCities = await _locationService.GetAllCity();
            if (allCities != null)
            {
                ViewBag.Cities = _mapper.Map<List<CityViewModel>>(allCities);
            }
            var allDistrict = await _locationService.GetAllDistrict();
            if (allDistrict != null)
            {
                ViewBag.Districts = _mapper.Map<List<DistrictViewModel>>(allDistrict);
            }
            return View(_mapper.Map<UserViewModel>(user));
        }

        [HttpPost]
        public async Task<IActionResult> Update(UserViewModel userViewModel)
            {
            var user = await _userService.GetUserWithDetail(userViewModel.Id);
            if (userViewModel?.UserDetail?.PhotoUrl != null && userViewModel.UserDetail.PhotoUrl.Length > 0)
            {
                // Mevcut fotoğrafı kontrol edin ve silin
                if (!string.IsNullOrEmpty(userViewModel.UserDetail.Photo))
                {
                    var existingFilePath = Path.Combine("wwwroot", "img", userViewModel.UserDetail.Photo);
                    if (System.IO.File.Exists(existingFilePath))
                    {
                        System.IO.File.Delete(existingFilePath); // Eski fotoğrafı sil
                    }
                }

                // Yeni fotoğrafı yükle
                var uniqueFileName = $"{Guid.NewGuid()}_{Path.GetFileName(userViewModel.UserDetail.PhotoUrl.FileName)}";
                var filePath = Path.Combine("wwwroot", "img", uniqueFileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await userViewModel.UserDetail.PhotoUrl.CopyToAsync(stream);
                }

                // Modelin Photo özelliğini yeni dosya adıyla güncelle
                userViewModel.UserDetail.Photo = uniqueFileName;
            }
            else 
            {//photo seçmediyse null ise eski photo verisileri yükle
               
                
                userViewModel.UserDetail.Photo = user?.UserDetail?.Photo;
            }
           
            if (userViewModel != null)
            { //userdetail hiç newlenmamişse yeni bir userdetail oluştur
                if (userViewModel?.UserDetailId == 0)
                {
                    userViewModel.UserDetail.Photo= "profileimg.png";
                    await _userDetailService.CreateUserDetail(_mapper.Map<UserDetailDto>(userViewModel?.UserDetail));
                    //yeni userdetail ıdsini user.userdetail ekle
                    var userDetails = await _userDetailService.GetUserDetailAll();
                    var newestUserDetail = userDetails.OrderByDescending(x => x.Id).FirstOrDefault();
                    if (newestUserDetail != null)
                    {
                        userViewModel.UserDetailId = newestUserDetail.Id;
                    }
                }
                else
                { //user detail mevcutsa verileri güncelle
                    await _userDetailService.UpdateUserDetail(_mapper.Map<UserDetailDto>(userViewModel?.UserDetail));

                }
                //user güncelle
                await _userService.UpdateUser(_mapper.Map<UserDto>(userViewModel));
               
            }
            return RedirectToAction("Index", "User");

        }
    }
}