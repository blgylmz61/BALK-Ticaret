using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entites
{
    public class Country:BaseEntity
    {
        public string TwoCode { get; set; }
        public string Name { get; set; }
        public string PhoneCode { get; set; }
        public List<City> Cities { get; set; }

    }
}
