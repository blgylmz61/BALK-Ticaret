using DAL.Entites;

namespace BALK_Ticaret.Models
{
    public class CityViewModel : BaseEntityViewModel
    {
        public string Name { get; set; }
        public int CountryId { get; set; }
        public CountryViewModel CountryViewModel { get; set; }
        public List<DistrictViewModel>? DistrictViewModels { get; set; }

    }
}
