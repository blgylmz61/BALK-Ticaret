using BLL.Dtos;

namespace BALK_Ticaret.Models
{
    public class DistrictViewModel:BaseEntityViewModel
    {
        public string Name { get; set; }
        public int CityId { get; set; }
        public CityViewModel? CityViewModel { get; set; }
    }
}
