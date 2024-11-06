using DAL.Entites;

namespace BALK_Ticaret.Models
{
    public class ProductDetailViewModel : BaseEntityViewModel
    {
        public string Site { get; set; }
        public string Flat { get; set; }
        public string Apartmennt { get; set; }
        public string DaireNo { get; set; }
        public int CountryId { get; set; }
        public int CityId { get; set; }
        public int DistrictId { get; set; }
        public CountryViewModel CountryViewModel { get; set; }
        public CityViewModel CityViewModel { get; set; }
        public DistrictViewModel DistrictViewModel { get; set; }
        public int ProductId { get; set; }
        public ProductViewModel ProductViewModel { get; set; }
    }
}
