using DAL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Dtos
{
    public class OrderItemDto:BaseEntityDto
    {
        public int OrderId { get; set; }                 // Sipariş kimliği
        public OrderDto OrderDto { get; set; }// Sipariş ile ilişki

        public int ProductId { get; set; }
        public decimal Price { get; set; }

        public int Quantity { get; set; }  // Sipariş edilen ürün miktarı
        public decimal UnitPrice { get; set; }           // Sipariş edilen ürün birim fiyatı
    }
}
