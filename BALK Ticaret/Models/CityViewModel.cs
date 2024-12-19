using DAL.Entites;

namespace BALK_Ticaret.Models
{
    public class CityViewModel : BaseEntityViewModel
    {
        public string Name { get; set; }
        public int CountryId { get; set; }
        public CountryViewModel Country { get; set; }
        public List<DistrictViewModel>? Districts { get; set; }


    }
}
