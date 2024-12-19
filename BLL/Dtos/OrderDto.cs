using DAL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Dtos
{
    public class OrderDto:BaseEntityDto
    {
        public DateTime OrderDate { get; set; }
        public int UserId { get; set; }
        public UserDto User { get; set; }
        public BillDto Bill { get; set; }
        public List<PaymentDto> Payments { get; set; }
        public List<OrderItemDto> OrderItems { get; set; }
        public decimal TotalAmount { get; set; }

    }
}
