using DAL.Entites;

namespace BALK_Ticaret.Models
{
    public class OrderViewModel : BaseEntityViewModel
    {
        public DateTime OrderDate { get; set; }
        public int UserId { get; set; }
        public UserViewModel User { get; set; }
        public BillViewModel Bill { get; set; }

        public List<PaymentViewModel> Payments { get; set; }
        public List<OrderItemViewModel> OrderItems { get; set; }
        public decimal TotalAmount { get; set; }

    }
}
