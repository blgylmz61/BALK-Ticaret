using DAL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Dtos
{
    public class PaymentDto
    {
        public int OrderId { get; set; }
        public OrderDto OrderDto { get; set; }                  // Ödeme-Sipariş ilişkisi

        public decimal Amount { get; set; }               // Ödeme tutarı
        public DateTime PaymentDate { get; set; }         // Ödeme tarihi
    }
}
