using DAL.Entites;

namespace BALK_Ticaret.Models
{
    public class ProductLikeViewModel : BaseEntityViewModel
    {
        public bool IsLike { get; set; }

        public int ProductId { get; set; }
        public ProductViewModel Product { get; set; }
        public int UserId { get; set; }
        public UserViewModel User { get; set; }
    }
}
