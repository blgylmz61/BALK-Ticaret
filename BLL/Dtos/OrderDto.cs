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
        public UserDto UserDto { get; set; }
        public BillDto BillDto { get; set; }

        public List<PaymentDto> PaymentDtos { get; set; }
        public List<OrderItemDto> OrderItemDtos { get; set; }
        public decimal TotalAmount { get; set; }

    }
}
