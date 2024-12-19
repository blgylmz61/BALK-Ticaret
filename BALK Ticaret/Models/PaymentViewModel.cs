using DAL.Entites;

namespace BALK_Ticaret.Models
{
    public class PaymentViewModel:BaseEntityViewModel
    {
        public int OrderId { get; set; }
        public OrderViewModel Order { get; set; }                  // Ödeme-Sipariş ilişkisi

        public decimal Amount { get; set; }               // Ödeme tutarı
        public DateTime PaymentDate { get; set; }         // Ödeme tarihi
    }
}
