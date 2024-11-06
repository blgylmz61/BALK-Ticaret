using AutoMapper;
using BALK_Ticaret.Models;
using BLL.AbstractServices;
using BLL.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace BALK_Ticaret.Controllers
{
    public class UserRoleController : Controller
    {
        private readonly IUserRoleService _userRoleService;
        private readonly IMapper _mapper;

        public UserRoleController(IUserRoleService userRoleService,IMapper mapper)
        {
            _userRoleService = userRoleService;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var userRoles=await _userRoleService.GetUserRoleAll();
            return View(_mapper.Map<List<UserRoleViewModel>>(userRoles));
        }
       
        public IActionResult Create() { 

        return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(UserRoleViewModel userRoleViewModel)
        {
            if (userRoleViewModel != null)
            {
                var userRoleDto = _mapper.Map<UserRoleDto>(userRoleViewModel);
                await _userRoleService.CreateUserRole(userRoleDto);
                return RedirectToAction("Index", "UserRole");
            }
            else
            {
                return View();

            }

        }

    }
}
