using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entites
{
    public class Gender:BaseEntity
    {
        public string Name { get; set; }
      
        public List<UserDetail> UserDetails { get; set; }
    }
}
