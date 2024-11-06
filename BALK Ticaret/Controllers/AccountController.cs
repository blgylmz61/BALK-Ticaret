using AutoMapper;
using BALK_Ticaret.Models;
using BLL.AbstractServices;
using BLL.Dtos;
using DAL.Entites;
using Microsoft.AspNetCore.Mvc;

namespace BALK_Ticaret.Controllers
{
    public class AccountController : Controller
    {
        private readonly IGenderService _genderService;
        private readonly IUserService _userService;
        private readonly IUserRoleService _userRoleService;
        private readonly IUserDetailService _userDetailService;
        private readonly IAddressService _addressService;
        private readonly IMapper _mapper;

        public AccountController(IGenderService genderService, IUserService userService, IUserRoleService userRoleService, IUserDetailService userDetailService, IAddressService addressService, IMapper mapper)
        {
            _genderService = genderService;
            _userService = userService;
            _userRoleService = userRoleService;
            _userDetailService = userDetailService;
            _addressService = addressService;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            var userDto = await _userService.Login(username, password);
            if (userDto != null)
            {
                var userViewModel = _mapper.Map<UserDto>(userDto);
                HttpContext.Session.SetInt32("UserId", userViewModel.Id);
                HttpContext.Session.SetString("UserName", userViewModel.Username);
                if (userViewModel.UserDetailDto != null && userViewModel.UserDetailDto.Photo != null)
                {
                    TempData["UserPhoto"] = userViewModel.UserDetailDto.Photo;
                }
                if (userViewModel.UserRoleId == 1)
                {
                    HttpContext.Session.SetString("IsAdmin", "true");
                    return RedirectToAction("Admin", "Account");
                }
                return RedirectToAction("Index", "Home");
            }
            ViewBag.Hata = "Lütfen geçerli bir Kullanıcı Adı ve Şifre giriniz.";

            return View();
        }
        public IActionResult Admin()
        {
            return View();
        }
        public async Task<IActionResult> Register()
        {
            var allUserRoles = await _userRoleService.GetUserRoleAll();
            ViewBag.UserRoles = allUserRoles;
            var allGenders = await _genderService.GetAllGender();
            ViewBag.Genders = allGenders;
            var allCountries = await _addressService.GetAllCountry();
            ViewBag.Countries = allCountries;
            var allCities = await _addressService.GetAllCity();
            ViewBag.Cities = allCities;
            var allDistrict = await _addressService.GetAllDistrict();
            ViewBag.Districts = allDistrict;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(UserViewModel userViewModel)
        {
            var checkedUsername = await _userService.CheckUsername(userViewModel.Username);
            if (checkedUsername)
            {
                ViewBag.SameUsername = "Bu Kullanıcı adı sistemde kayıtlıdır.";
            }
            var checkedEmail = await _userService.CheckEmail(userViewModel.Email);
            if (checkedEmail)
            {
                ViewBag.SameEmail = "Bu Email adresi sistemde kayıtlıdır.";
            }
            var checkedTCNo = await _userDetailService.CheckTcNo(userViewModel?.UserDetailViewModel?.TcNo ?? string.Empty);
            if (checkedTCNo)
            {
                ViewBag.SameTcNo = "Bu Tc Numarası sistemde kayıtlıdır.";
            }

            if (userViewModel?.UserDetailViewModel?.PhotoUrl != null && userViewModel.UserDetailViewModel.PhotoUrl.Length > 0)
            {
                var uniqueFileName = $"{Guid.NewGuid()}_{Path.GetFileName(userViewModel.UserDetailViewModel.PhotoUrl.FileName)}";
                var fileName = Path.GetFileName(userViewModel.UserDetailViewModel.PhotoUrl.FileName);
                var filePath = Path.Combine("wwwroot", "img", uniqueFileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await userViewModel.UserDetailViewModel.PhotoUrl.CopyToAsync(stream);
                }
                userViewModel.UserDetailViewModel.Photo = uniqueFileName;
            }
            if (userViewModel?.UserDetailViewModel != null)
            {
                var userDetail = userViewModel.UserDetailViewModel;
                var userdetail = _mapper.Map<UserDetailDto>(userDetail);
                await _userDetailService.CreateUserDetail(userdetail);

            }
            var newUserDetails = await _userDetailService.GetUserDetailAll();
            var newestUserDetail = newUserDetails.OrderByDescending(x => x.Id).FirstOrDefault();
            if (newestUserDetail != null)
            {
                userViewModel.UserDetailId = newestUserDetail.Id;
            }
            await _userService.CreateUser(_mapper.Map<UserDto>(userViewModel));
           
           
            return RedirectToAction("Index", "User");
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Account");
        }
        public async Task<IActionResult> Profile()
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            
                var UserId = userId.Value;
                var User = await _userService.GetUserId(UserId);
            var user = _mapper.Map<UserViewModel>(User);
            var UserDetail = await _userDetailService.GetUserDetailById(user.UserDetailId);
            var userDetail = _mapper.Map<UserDetailViewModel>(UserDetail);
            if (userDetail != null)
            {

                var gender = await _genderService.GetGenderById(userDetail.GenderId);
                userDetail.Gender = _mapper.Map<GenderViewModel>(gender);

                var country = await _addressService.GetByIdCountry(userDetail.CountryId);
                userDetail.CountryViewModel = _mapper.Map<CountryViewModel>(country);

                var city = await _addressService.GetByIdCity(userDetail.CityId);
                userDetail.CityViewModel = _mapper.Map<CityViewModel>(city);

                var district = await _addressService.GetByIdDistrict(userDetail.DistrictId);
                userDetail.DistrictViewModel = _mapper.Map<DistrictViewModel>(district);

                user.UserDetailViewModel = userDetail;
            }
            return View(_mapper.Map<UserViewModel>(user));
        }

    }
}
