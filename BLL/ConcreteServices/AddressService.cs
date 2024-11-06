using AutoMapper;
using BLL.AbstractServices;
using BLL.Dtos;
using DAL.AbstractRepository;
using DAL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ConcreteServices
{
    public class AddressService:IAddressService
    {
        private readonly IRepository<Country> _countryRepository;
        private readonly IRepository<City> _cityRepository;
        private readonly IRepository<District> _districtRepository;
        private readonly IMapper _mapper;

        public AddressService(IRepository<Country> countryRepository, IRepository<City> cityRepository, IRepository<District> districtRepository, IMapper mapper)
        {
            _countryRepository = countryRepository;
           _cityRepository = cityRepository;
            _districtRepository = districtRepository;
            _mapper = mapper;
        }

        public async Task<List<CityDto>> GetAllCity()
        {
            var cities= await _cityRepository.GetAllAsync();
            return (_mapper.Map<List<CityDto>>(cities));
        }

        public async Task<List<CountryDto>> GetAllCountry()
        {
            var countries=await _countryRepository.GetAllAsync();
            return _mapper.Map<List<CountryDto>>(countries);    
        }

        public async Task<List<DistrictDto>> GetAllDistrict()
        {
            var districts= await _districtRepository.GetAllAsync();
            return _mapper.Map<List<DistrictDto>>(districts);
        }

        public async Task<IEnumerable<DistrictDto>> GetAllDistrictbyCityId(int cityId)
        {
            var districts = await _districtRepository.FindAsync(x => x.CityId == cityId);
            return _mapper.Map<IEnumerable<DistrictDto>>(districts);
        }

        public async Task<CityDto> GetByIdCity(int cityId)
        {
            var city=await _cityRepository.GetByIdAsync(cityId);
            return _mapper.Map<CityDto>(city);
        }

        public async Task<CountryDto> GetByIdCountry(int countryId)
        {
            var country=await _countryRepository.GetByIdAsync(countryId);
            return (_mapper.Map<CountryDto>(country));
        }

        public async Task<DistrictDto> GetByIdDistrict(int districtId)
        {
            var district=await _districtRepository.GetByIdAsync(districtId);
            return _mapper.Map<DistrictDto>(district);
        }
    }
}
