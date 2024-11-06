using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entites
{
    public class Cart:BaseEntity
    {
        public int UserId { get; set; }
        public  User User { get; set; }
        public List<CartItem> CartItems { get; set; }


    }
}
