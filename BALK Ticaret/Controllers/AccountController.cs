using AutoMapper;
using BALK_Ticaret.Models;
using BLL.AbstractServices;
using BLL.ConcreteServices;
using BLL.Dtos;
using DAL.Entites;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BALK_Ticaret.Controllers
{
    public class AccountController : Controller
    {
        private readonly IGenderService _genderService;
        private readonly IUserService _userService;
        private readonly IUserRoleService _userRoleService;
        private readonly IUserDetailService _userDetailService;
        private readonly ILocationService _locationService;
        private readonly IMapper _mapper;

        public AccountController(IGenderService genderService, IUserService userService, IUserRoleService userRoleService, IUserDetailService userDetailService, ILocationService locationService, IMapper mapper)
        {
            _genderService = genderService;
            _userService = userService;
            _userRoleService = userRoleService;
            _userDetailService = userDetailService;
            _locationService = locationService;
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
            var user = await _userService.Login(username, password);
            if (user != null)
            {
                var userViewModel = _mapper.Map<UserDto>(user);
                HttpContext.Session.SetInt32("UserId", userViewModel.Id);
                HttpContext.Session.SetString("UserName", userViewModel.Username);
                if (userViewModel.UserDetail != null && userViewModel.UserDetail.Photo != null)
                {
                    TempData["UserPhoto"] = userViewModel.UserDetail.Photo;
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
            var allCountries = await _locationService.GetAllCountry();
            ViewBag.Countries = allCountries;
            var allCities = await _locationService.GetAllCity();
            ViewBag.Cities = allCities;
            var allDistrict = await _locationService.GetAllDistrict();
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
            var checkedTCNo = await _userDetailService.CheckTcNo(userViewModel?.UserDetail?.TcNo ?? string.Empty);
            if (checkedTCNo)
            {
                ViewBag.SameTcNo = "Bu Tc Numarası sistemde kayıtlıdır.";
            }

            if (userViewModel?.UserDetail?.PhotoUrl != null && userViewModel.UserDetail.PhotoUrl.Length > 0)
            {
                var uniqueFileName = $"{Guid.NewGuid()}_{Path.GetFileName(userViewModel.UserDetail.PhotoUrl.FileName)}";
                var fileName = Path.GetFileName(userViewModel.UserDetail.PhotoUrl.FileName);
                var filePath = Path.Combine("wwwroot", "img", uniqueFileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await userViewModel.UserDetail.PhotoUrl.CopyToAsync(stream);
                }
                userViewModel.UserDetail.Photo = uniqueFileName;
            }
            else
            {
                userViewModel.UserDetail.Photo = "profileimg.png";
            }
            if (userViewModel?.UserDetail != null)
            {
                var userDetail = userViewModel.UserDetail;
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

            //var product = productJson != null ? JsonConvert.DeserializeObject<ProductViewModel>(productJson) : null;

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
            
            var userFull = await _userService.GetUserWithDetail(user.Id);
            return View(_mapper.Map<UserViewModel>(userFull));
        }

    }
}
