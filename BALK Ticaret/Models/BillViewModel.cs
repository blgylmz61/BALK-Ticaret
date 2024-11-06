using DAL.Entites;

namespace BALK_Ticaret.Models
{
    public class BillViewModel : BaseEntityViewModel
    {
        public string Adress { get; set; }
        public int OrderId { get; set; }
        public DateTime BillDate { get; set; } // Fatura tarihi
        public decimal Amount { get; set; } // Fatura tutarı
        public OrderViewModel? OrderViewModel { get; set; }
        public int CountryId { get; set; }
        public int CityId { get; set; }
        public int DistrictId { get; set; }
        public CountryViewModel? CountryViewModel { get; set; }
        public CityViewModel? CityViewModel { get; set; }
        public DistrictViewModel? DistrictViewModel { get; set; }

    }
}
