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
    public interface IAddressService
    {
       
        Task<CountryDto> GetByIdCountry(int countryId);
        Task<List<CountryDto>> GetAllCountry();

        Task<CityDto> GetByIdCity(int cityId);
        Task<List<CityDto>> GetAllCity();

        Task<DistrictDto> GetByIdDistrict(int districtId);
        Task<List<DistrictDto>> GetAllDistrict();
        Task<IEnumerable<DistrictDto>> GetAllDistrictbyCityId(int cityId);
    }
}
