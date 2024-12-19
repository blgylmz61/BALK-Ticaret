using DAL.Entites;

namespace BALK_Ticaret.Models
{
    public class BillViewModel : BaseEntityViewModel
    {
        public string Adress { get; set; }
        public int OrderId { get; set; }
        public DateTime BillDate { get; set; } // Fatura tarihi
        public decimal Amount { get; set; } // Fatura tutarı
        public OrderViewModel? Order{ get; set; }
        public int CountryId { get; set; }
        public int CityId { get; set; }
        public int DistrictId { get; set; }
        public CountryViewModel? Country { get; set; }
        public CityViewModel? City { get; set; }
        public DistrictViewModel? District { get; set; }

    }
}
