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
    public class LocationService : ILocationService
    {
        private readonly IRepository<Country> _countryRepository;
        private readonly IRepository<City> _cityRepository;
        private readonly IRepository<District> _districtRepository;
        private readonly IMapper _mapper;
        private readonly IRepository<Neighborhood> _neighborhoodRepository;

        public LocationService(IRepository<Country> countryRepository, IRepository<City> cityRepository, IRepository<District> districtRepository, IMapper mapper, IRepository<Neighborhood> neighborhoodRepository)
        {
            _countryRepository = countryRepository;
            _cityRepository = cityRepository;
            _districtRepository = districtRepository;
            _mapper = mapper;
            _neighborhoodRepository = neighborhoodRepository;
        }

        //All Cities
        public async Task<List<CityDto>> GetAllCity()
        {
            var cities = await _cityRepository.GetAllAsync();
            return (_mapper.Map<List<CityDto>>(cities));
        }
        //All Country
        public async Task<List<CountryDto>> GetAllCountry()
        {
            var countries = await _countryRepository.GetAllAsync();
            return _mapper.Map<List<CountryDto>>(countries);
        }
        //All District
        public async Task<List<DistrictDto>> GetAllDistrict()
        {
            var districts = await _districtRepository.GetAllAsync();
            return _mapper.Map<List<DistrictDto>>(districts);
        }
        //All Neighborhood
        public async Task<List<NeighborhoodDto>> GetAllNeighborhood()
        {
            var neighborhoods = await _neighborhoodRepository.GetAllAsync();
            return _mapper.Map<List<NeighborhoodDto>>(neighborhoods);
        }
        //one country
        public async Task<CountryDto> GetByIdCountry(int countryId)
        {
            var country = await _countryRepository.GetByIdAsync(countryId);
            return (_mapper.Map<CountryDto>(country));
        }
        //one city
        public async Task<CityDto> GetByIdCity(int cityId)
        {
            var city = await _cityRepository.GetByIdAsync(cityId);
            return _mapper.Map<CityDto>(city);
        }

        //one district
        public async Task<DistrictDto> GetByIdDistrict(int districtId)
        {
            var district = await _districtRepository.GetByIdAsync(districtId);
            return _mapper.Map<DistrictDto>(district);
        }
        //one neighborhood
        public async Task<NeighborhoodDto> GetByIdNeighborhood(int neighborhoodId)
        {
            var neighborhood = await _neighborhoodRepository.GetByIdAsync(neighborhoodId);
            return _mapper.Map<NeighborhoodDto>(neighborhood);
        }
        //city's all Districts
        public async Task<IEnumerable<DistrictDto>> GetDistrictsByCityId(int cityId)
        {
            var districts = await _districtRepository.FindAsync(x => x.CityId == cityId);
            return (_mapper.Map<IEnumerable<DistrictDto>>(districts));
        }

        //Country's AllCities

        public async Task<IEnumerable<CityDto>> GetCitiesByCountryId(int countryId)
        {
            var cities = await _cityRepository.FindAsync(x => x.CountryId == countryId);
            return (_mapper.Map<IEnumerable<CityDto>>(cities));
        }
        //district's All Neigborhoodsr

        public async Task<IEnumerable<NeighborhoodDto>> GetNeighborhoodsByDistrictId(int districtId)
        {
            var neighborhoods = await _neighborhoodRepository.FindAsync(x => x.DistrictId == districtId);
            return (_mapper.Map<IEnumerable<NeighborhoodDto>>(neighborhoods));
        }


    }
}
