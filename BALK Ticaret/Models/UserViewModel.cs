using DAL.Entites;
using System.ComponentModel.DataAnnotations;

namespace BALK_Ticaret.Models
{
    public class UserViewModel : BaseEntityViewModel
    {
        [Required]
        [MaxLength(50, ErrorMessage = "En fazla 30 Karakter olmalıdır!")]
        [MinLength(3, ErrorMessage = "En az 2 Karakter içermelidir.")]
        public string Name { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "En fazla 30 Karakter olmalıdır!")]
        [MinLength(3, ErrorMessage = "En az 2 Karakter içermelidir.")]
        public string Surname { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Geçerli bir e-mail adresi giriniz.")]
        public string Email { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Geçerli bir e-mail adresi giriniz.")]
        public string Password { get; set; }
        [Required]
        public string Username { get; set; }
        public int UserRoleId { get; set; }
        public int UserDetailId { get; set; }

        public UserRoleViewModel UserRole { get; set; }
 
        public UserDetailViewModel? UserDetail { get; set; }
     
        public List<ProductLikeViewModel>? ProductLikes { get; set; }
       
        public CartViewModel ?Cart { get; set; }
        public List<OrderViewModel> ?Orders { get; set; }
        public List<CardViewModel> Cards { get; set; }
       


    }
}
