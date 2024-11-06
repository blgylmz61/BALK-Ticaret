using DAL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Dtos
{
    public class CountryDto:BaseEntityDto
    {
        public string TwoCode { get; set; }
        public string Name { get; set; }
        public string PhoneCode { get; set; }
        public List<CityDto> CityDtos { get; set; }

    }
}
