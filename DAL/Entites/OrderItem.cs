using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entites
{
    public class OrderItem : BaseEntity
    {
        public int OrderId { get; set; } // Sipariş kimliği
        public Order Order { get; set; } // Sipariş ile ilişki
        public int ProductId { get; set; }
        public int Quantity { get; set; }  // Sipariş edilen ürün miktarı
        public decimal Price { get; set; }
        public decimal UnitPrice { get; set; }  // Sipariş edilen ürün birim fiyatı
    }
}
