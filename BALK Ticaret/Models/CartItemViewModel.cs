using BLL.Dtos;
using DAL.Entites;

namespace BALK_Ticaret.Models
{
    public class CartItemViewModel : BaseEntityViewModel
    {
        public int ProductId { get; set; }                     // Ürün kimliği

        public decimal UnitPrice { get; set; }                 // Ürün birim fiyatı
        public int CartId { get; set; }
        public CartViewModel CartViewModel { get; set; }

    }
}
