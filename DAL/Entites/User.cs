using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entites
{
    public class User:BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        public int UserRoleId { get; set; }
        public UserRole UserRole { get; set; }
        public int ?UserDetailId { get; set; }
        public UserDetail ?UserDetail { get; set; }
        public List<ProductLike>? ProductLikes { get; set; }
        public Cart? Cart { get; set; }
        public  List<Order>? Orders { get; set; }
        public List<Card>? Cards { get; set; }



    }
}
