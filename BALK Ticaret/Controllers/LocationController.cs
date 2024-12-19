using AutoMapper;
using BALK_Ticaret.Models;
using BLL.AbstractServices;
using BLL.ConcreteServices;
using DAL.Entites;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BALK_Ticaret.Controllers
{
    public class LocationController : Controller
    {
        private readonly ILocationService _locationService;
        private readonly IMapper _mapper;

        public LocationController(ILocationService locationService,IMapper mapper)
        {
            _locationService = locationService;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<JsonResult> GetCities(int countryId)
        {
            
            var Cities =await  _locationService.GetCitiesByCountryId(countryId);
            var cities = _mapper.Map < IEnumerable<CityViewModel>>(Cities);
            return Json(cities); // Şehirleri JSON formatında döner
        }

        [HttpGet]
        public async Task<JsonResult> GetDistricts(int cityId)
        {
            var districts = await _locationService.GetDistrictsByCityId(cityId);
            return Json(districts); // İlçeleri JSON formatında döner
        }

        [HttpGet]
        public async Task<JsonResult> GetNeighborhoods(int districtId)
        {
            var neighborhoods = await _locationService.GetNeighborhoodsByDistrictId(districtId);
            return Json(neighborhoods); // Mahalleleri JSON formatında döner
        }

    }
}
