using DAL.Entites;

namespace BALK_Ticaret.Models
{
    public class ProductLikeViewModel : BaseEntityViewModel
    {
        public int ProductId { get; set; }
        public ProductViewModel ProductViewModel { get; set; }
        public int UserId { get; set; }
        public UserViewModel UserViewModel { get; set; }
    }
}
