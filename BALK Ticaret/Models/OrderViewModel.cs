using DAL.Entites;

namespace BALK_Ticaret.Models
{
    public class OrderViewModel : BaseEntityViewModel
    {
        public DateTime OrderDate { get; set; }
        public int UserId { get; set; }
        public UserViewModel UserViewModel { get; set; }
        public BillViewModel BillViewModel { get; set; }

        public List<PaymentViewModel> PaymentViewModels { get; set; }
        public List<OrderItemViewModel> OrderItemViewModels { get; set; }
        public decimal TotalAmount { get; set; }

    }
}
