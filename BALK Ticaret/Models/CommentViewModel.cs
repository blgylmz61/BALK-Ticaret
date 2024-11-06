using DAL.Entites;

namespace BALK_Ticaret.Models
{
    public class CommentViewModel : BaseEntityViewModel
    {

        public int UserId { get; set; }
        public UserViewModel UserViewModel { get; set; }
        public int ProductId { get; set; }
        public ProductViewModel ProductViewModel { get; set; }
        public string Description { get; set; }
        public int Scor { get; set; }
    }
}
