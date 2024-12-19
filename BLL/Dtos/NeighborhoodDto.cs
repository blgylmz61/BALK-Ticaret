using DAL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Dtos
{
    public class NeighborhoodDto:BaseEntityDto
    {

        public string Name { get; set; }
        public int DistrictId { get; set; }
        public DistrictDto District { get; set; }
    }
}
