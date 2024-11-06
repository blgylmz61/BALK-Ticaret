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
        private readonly IAddressService _addressService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly IUserDetailService _userDetailService;
        private readonly IUserRoleService _userRoleService;
        private readonly IGenderService _genderService;

        public UserController(IAddressService addressService, IUserService userService, IMapper mapper, IUserDetailService userDetailService, IUserRoleService userRoleService, IGenderService genderService)
        {
            _addressService = addressService;
            _userService = userService;
            _mapper = mapper;
            _userDetailService = userDetailService;
            _userRoleService = userRoleService;
            _genderService = genderService;
        }
        public async Task<IActionResult> Index()
        {

            var users = await _userService.GetAllUsers();
            var userRoles = await _userRoleService.GetUserRoleAll();
            ViewBag.UserRoles = _mapper.Map<List<UserRoleViewModel>>(userRoles);
            var genders = await _genderService.GetAllGender();
            ViewBag.Genders = _mapper.Map<List<GenderViewModel>>(genders);
            var userDetails = await _userDetailService.GetUserDetailAll();
            ViewBag.UserDetails = _mapper.Map<List<UserDetailViewModel>>(userDetails);
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
            var user = await _userService.GetUserId(userId);
            var userDetail = await _userDetailService.GetUserDetailById(user.UserDetailId);
            if (userDetail != null)
            {
                ViewBag.UserDetail = _mapper.Map<UserDetailViewModel>(userDetail);
            }
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
            var allCountries = await _addressService.GetAllCountry();
            if (allCountries != null)
            {
                ViewBag.Countries = _mapper.Map<List<CountryViewModel>>(allCountries);
            }
            var allCities = await _addressService.GetAllCity();
            if (allCities != null)
            {
                ViewBag.Cities = _mapper.Map<List<CityViewModel>>(allCities);
            }
            var allDistrict = await _addressService.GetAllDistrict();
            if (allDistrict != null)
            {
                ViewBag.Districts = _mapper.Map<List<DistrictViewModel>>(allDistrict);
            }
            return View(_mapper.Map<UserViewModel>(user));
        }

        [HttpPost]
        public async Task<IActionResult> Update(UserViewModel userViewModel)
        {
            if (userViewModel?.UserDetailViewModel?.PhotoUrl != null && userViewModel.UserDetailViewModel.PhotoUrl.Length > 0)
            {
                // Mevcut fotoğrafı kontrol edin ve silin
                if (!string.IsNullOrEmpty(userViewModel.UserDetailViewModel.Photo))
                {
                    var existingFilePath = Path.Combine("wwwroot", "img", userViewModel.UserDetailViewModel.Photo);
                    if (System.IO.File.Exists(existingFilePath))
                    {
                        System.IO.File.Delete(existingFilePath); // Eski fotoğrafı sil
                    }
                }

                // Yeni fotoğrafı yükle
                var uniqueFileName = $"{Guid.NewGuid()}_{Path.GetFileName(userViewModel.UserDetailViewModel.PhotoUrl.FileName)}";
                var filePath = Path.Combine("wwwroot", "img", uniqueFileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await userViewModel.UserDetailViewModel.PhotoUrl.CopyToAsync(stream);
                }

                // Modelin Photo özelliğini yeni dosya adıyla güncelle
                userViewModel.UserDetailViewModel.Photo = uniqueFileName;
            }
            else
            {//photo seçmediyse null ise eski photo verisileri yükle
                var user = await _userService.GetUserId(userViewModel.Id);
                var getUserDetail = await _userDetailService.GetUserDetailById(user.UserDetailId);
                    var userDetail = _mapper.Map<UserDetailViewModel>(getUserDetail);
                userViewModel.UserDetailViewModel.Photo = userDetail.Photo;
            }
            if (userViewModel != null)
            { //userdetail hiç newlenmamişse yeni bir userdetail oluştur
                if (userViewModel?.UserDetailId == 0)
                {
                    await _userDetailService.CreateUserDetail(_mapper.Map<UserDetailDto>(userViewModel?.UserDetailViewModel));
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
                    await _userDetailService.UpdateUserDetail(_mapper.Map<UserDetailDto>(userViewModel?.UserDetailViewModel));

                }
                //user güncelle
                await _userService.UpdateUser(_mapper.Map<UserDto>(userViewModel));
               
            }
            return RedirectToAction("Index", "User");

        }
    }
}