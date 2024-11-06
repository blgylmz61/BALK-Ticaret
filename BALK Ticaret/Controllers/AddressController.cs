using AutoMapper;
using BLL.AbstractServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BALK_Ticaret.Controllers
{
    public class AddressController : Controller
    {
        private readonly IAddressService _addressService;
        

        public AddressController(IAddressService addressService)
        {
            _addressService = addressService;
            
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<JsonResult> GetDistricts(int cityId)
        {
            try
            {
                var districts = await _addressService.GetAllDistrictbyCityId(cityId);

                if (districts == null || !districts.Any())
                {
                    return Json(new List<object>()); // Boş bir liste döndür
                }

                var districtList = districts.Select(d => new
                {
                    d.Id,
                    d.Name
                }).ToList();

                return Json(districtList);
            }
            catch (Exception ex)
            {
                // Loglama yapılabilir
                return Json(new { success = false, message = ex.Message });
            }
        }

    }
}
