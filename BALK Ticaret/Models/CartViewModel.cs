using DAL.Entites;

namespace BALK_Ticaret.Models
{
    public class CartViewModel : BaseEntityViewModel
    {
        public int UserId { get; set; }
        public UserViewModel UserViewModel { get; set; }

        public List<CartItemViewModel> CartItemViewModels { get; set; }
    }
}
