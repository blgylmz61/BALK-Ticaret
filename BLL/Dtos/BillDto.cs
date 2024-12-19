using DAL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Dtos
{
    public class BillDto:BaseEntityDto
    {
        public string Adress { get; set; }
        public int OrderId { get; set; }
        public DateTime BillDate { get; set; } // Fatura tarihi
        public decimal Amount { get; set; } // Fatura tutarı
        public OrderDto Order { get; set; }
        public int CountryId { get; set; }
        public int CityId { get; set; }
        public int DistrictId { get; set; }
        public CountryDto Country { get; set; }
        public CityDto City { get; set; }
        public DistrictDto District { get; set; }

    }
}
