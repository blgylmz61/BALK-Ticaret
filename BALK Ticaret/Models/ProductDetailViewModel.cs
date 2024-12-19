using DAL.Entites;

namespace BALK_Ticaret.Models
{
    public class ProductDetailViewModel : BaseEntityViewModel
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
        public NeighborhoodViewModel Neighborhood { get; set; }
        public CountryViewModel Country { get; set; }
        public CityViewModel City { get; set; }
        public DistrictViewModel District { get; set; }
        public int ProductId { get; set; }
        public ProductViewModel Product { get; set; }
    }
}
