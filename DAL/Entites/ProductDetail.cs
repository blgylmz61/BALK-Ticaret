using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entites
{
    public class ProductDetail:BaseEntity
    {
        public string? Site { get; set; }
        public string? Flat { get; set; }
        public string? Apartmennt { get; set; }
        public string? DaireNo { get; set; }
        public int? CountryId { get; set; }
        public int? CityId { get; set; }
        public int? DistrictId { get; set; }
        public Country Country { get; set; }
        public City City { get; set; }
        public District District { get; set; }
        public Product Product { get; set; }


    }
}
