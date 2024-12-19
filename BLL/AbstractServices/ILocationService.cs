using AutoMapper;
using BLL.Dtos;
using DAL.AbstractRepository;
using DAL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.AbstractServices
{
    public interface ILocationService
    {
       
        Task<CountryDto> GetByIdCountry(int countryId);
        Task<List<CountryDto>> GetAllCountry();

        Task<CityDto> GetByIdCity(int cityId);
        Task<List<CityDto>> GetAllCity();
        Task<IEnumerable<CityDto>> GetCitiesByCountryId(int countryId);


        Task<DistrictDto> GetByIdDistrict(int districtId);
        Task<List<DistrictDto>> GetAllDistrict();
        Task<IEnumerable<DistrictDto>> GetDistrictsByCityId(int cityId);

        Task<NeighborhoodDto> GetByIdNeighborhood(int neighborhoodId);
        Task<List<NeighborhoodDto>> GetAllNeighborhood();
        Task<IEnumerable<NeighborhoodDto>> GetNeighborhoodsByDistrictId(int districtId);


    }
}
