using DAL.Entites;
using System.ComponentModel.DataAnnotations;

namespace BALK_Ticaret.Models
{
    public class CardViewModel:BaseEntityViewModel
    {

        [Required(ErrorMessage = "Kart sahibi adı gereklidir.")]
        [StringLength(100, ErrorMessage = "Kart sahibi adı en fazla 100 karakter olabilir.")]
        public string CardHolder { get; set; }
        [Required(ErrorMessage = "Kart numarası gereklidir.")]
        [StringLength(16, MinimumLength = 16, ErrorMessage = "Kart numarası 16 rakam olmalıdır.")]
        [RegularExpression(@"^\d{16}$", ErrorMessage = "Geçersiz kart numarası.")]
        public string CardNumber { get; set; }

        [Required(ErrorMessage = "Son kullanma tarihi gereklidir.")]
        [DataType(DataType.Date)]
        public DateTime ExpiryDate { get; set; }
        [Required(ErrorMessage = "CVV gereklidir.")]
        [StringLength(3, MinimumLength = 3, ErrorMessage = "CVV 3 rakam olmalıdır.")]
        [RegularExpression(@"^\d{3}$", ErrorMessage = "Geçersiz CVV.")]
        public string Cvv { get; set; }
        public int UserId { get; set; }
        public UserViewModel User { get; set; }
        public DateTime CreatedAt { get; set; } 

    }
}
