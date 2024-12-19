using DAL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Dtos
{
    public class CartItemDto:BaseEntityDto
    {
        public int ProductId { get; set; }                     // Ürün kimliği
        public decimal UnitPrice { get; set; }                 // Ürün birim fiyatı
        public int CartId { get; set; }
        public CartDto CartDto { get; set; }
    }
}
