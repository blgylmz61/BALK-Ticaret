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

        public string? Site { get; set; }
        public string? Flat { get; set; }
        public string? Apartmennt { get; set; }
        public string? Type { get; set; } //konnut tipi
        public string? ZoningPlan { get; set; } //imar planı
        public double PeriodicIncrease { get; set; } //Dönemsel artış
        public int MaturityOptions { get; set; } //vade 
        public double Deposit { get; set; } //peşinat
        public int? DaireNo { get; set; }

        public int CountryId { get; set; }
        public int CityId { get; set; }
        public int DistrictId { get; set; }
        public int? NeighborhoodId { get; set; }
        public NeighborhoodDto Neighborhood { get; set; }
        public CountryDto CountryDto { get; set; }
        public CityDto CityDto { get; set; }
        public DistrictDto DistrictDto { get; set; }
        public ProductDto ProductDto { get; set; }
    }
}
