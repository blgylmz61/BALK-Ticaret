using DAL.Entites;

namespace BALK_Ticaret.Models
{
    public class CommentViewModel : BaseEntityViewModel
    {

        public int UserId { get; set; }
        public UserViewModel User { get; set; }
        public int ProductId { get; set; }
        public ProductViewModel Product { get; set; }
        public string Description { get; set; }
        public int Scor { get; set; }
        public DateTime CommentDate { get; set; }

    }
}
