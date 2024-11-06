using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entites
{
    public class UserDetail : BaseEntity
    {
        public DateTime Birthday { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string TcNo { get; set; }
        public string Photo { get; set; }
        public int CountryId { get; set; }
        public int CityId { get; set; }
        public int  DistrictId { get; set; }
        public int GenderId { get; set; }
        public Country Country { get; set; }
        public City City { get; set; }
        public District District { get; set; }
        public User User { get; set; }
        public Gender? Gender { get; set; }
    }
}
