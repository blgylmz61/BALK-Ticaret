using BLL.Dtos;
using DAL.Entites;

namespace BALK_Ticaret.Models
{
    public class OrderItemViewModel:BaseEntityViewModel
    {
        public int OrderId { get; set; }                 // Sipariş kimliği
        public OrderViewModel Order { get; set; }// Sipariş ile ilişki

        public int ProductId { get; set; }
        public decimal Price { get; set; }

        public int Quantity { get; set; }  // Sipariş edilen ürün miktarı
        public decimal UnitPrice { get; set; }           // Sipariş edilen ürün birim fiyatı
    }
}
