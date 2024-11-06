using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entites
{
    public class Order:BaseEntity
    {
        public DateTime OrderDate { get; set; }
        public  int UserId { get; set; }
        public  User User { get; set; }
        public decimal TotalAmount { get; set; }
        public Bill Bill { get; set; }
        public  List<Payment> Payments { get; set; }
        public List<OrderItem> OrderItems { get; set; } 
    }
}
