using DAL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Dtos
{
    public class DistrictDto:BaseEntityDto
    {
        public string Name { get; set; }
        public int? CityId { get; set; }
        public CityDto? City { get; set; }

    }
}
