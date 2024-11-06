using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entites
{
    public class CartItem:BaseEntity
    {
        public int ProductId { get; set; }                     // Ürün kimliği
        
        public decimal UnitPrice { get; set; }                 // Ürün birim fiyatı
        public int CartId { get; set; }
        public Cart Cart { get; set; }
    }
}
