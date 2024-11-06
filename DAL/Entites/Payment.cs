using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entites
{
    public class Payment:BaseEntity
    {
        public int OrderId { get; set; }
        public Order Order { get; set; }                  // Ödeme-Sipariş ilişkisi

        public decimal Amount { get; set; }               // Ödeme tutarı
        public DateTime PaymentDate { get; set; }         // Ödeme tarihi
    }
}
