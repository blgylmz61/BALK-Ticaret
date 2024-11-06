using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entites
{
    public class UserRole:BaseEntity
    {
        public string Role { get; set; }
        public string Description { get; set; }
        public List<User> Users { get; set; }
    }
}
