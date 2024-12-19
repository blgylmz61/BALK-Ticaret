using DAL.Entites;

namespace BALK_Ticaret.Models
{
    public class CartViewModel : BaseEntityViewModel
    {
        public int UserId { get; set; }
        public UserViewModel User { get; set; }

        public List<CartItemViewModel> CartItems { get; set; }
    }
}
