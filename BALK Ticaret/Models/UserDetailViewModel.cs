using DAL.Entites;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BALK_Ticaret.Models
{
    public class UserDetailViewModel : BaseEntityViewModel
    {
        public DateTime Birthday { get; set; }
        public int GenderId { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string TcNo { get; set; }
        public string Photo { get; set; }
        public int CountryId { get; set; }
        public int CityId { get; set; }
        public int DistrictId { get; set; }
        public CountryViewModel? CountryViewModel{ get; set; }
        public CityViewModel? CityViewModel { get; set; }
        public DistrictViewModel? DistrictViewModel { get; set; }
        public IFormFile? PhotoUrl { get; set; }
        public UserViewModel? UserViewModel { get; set; }
        public GenderViewModel? Gender { get; set; }
    }
}
