using DAL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Dtos
{
    public class ProductDetailDto:BaseEntityDto
    {
        public string Site { get; set; }
        public string Flat { get; set; }
        public string Apartmennt { get; set; }
        public string DaireNo { get; set; }
        public int CountryId { get; set; }
        public int CityId { get; set; }
        public int DistrictId { get; set; }
        public CountryDto CountryDto { get; set; }
        public CityDto CityDto { get; set; }
        public DistrictDto DistrictDto { get; set; }
        public ProductDto ProductDto { get; set; }
    }
}
