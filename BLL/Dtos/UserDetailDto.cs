using DAL.Entites;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Dtos
{
    public class UserDetailDto : BaseEntityDto  
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
        public CountryDto CountryDto { get; set; }
        public CityDto CityDto { get; set; }
        public DistrictDto DistrictDto { get; set; }
        public UserDto UserDto { get; set; }
        public GenderDto Gender { get; set; }

    }
}
