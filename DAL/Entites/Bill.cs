using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entites
{
    public class Bill:BaseEntity
    {
        public string Adress { get; set; }
        public int OrderId { get; set; }
        public DateTime BillDate { get; set; } // Fatura tarihi
        public decimal Amount { get; set; } // Fatura tutarı
        public int CountryId { get; set; }
        public int CityId { get; set; }
        public int DistrictId { get; set; }
        public Country Country { get; set; }
        public City City { get; set; }
        public District District { get; set; }
        public Order Order { get; set; }


    }
}
