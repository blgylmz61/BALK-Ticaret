using DAL.Entites;

namespace BALK_Ticaret.Models
{
    public class CountryViewModel:BaseEntityViewModel
    {
        public string TwoCode { get; set; }
        public string Name { get; set; }
        public string PhoneCode { get; set; }
        public List<CityViewModel>? CityViewModels { get; set; }

    }
}
