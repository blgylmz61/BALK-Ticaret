using DAL.Entites;

namespace BALK_Ticaret.Models
{
    public class ProductViewModel : BaseEntityViewModel
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public List<IFormFile> ?PhotoUrls { get; set; } // Birden fazla dosya için liste
        public List<string> ?Photos { get; set; }  // Kaydedilen dosya isimlerini tutmak için
        public string? Description { get; set; }
        public int LikeCount { get; set; }
        public decimal UnitPriceM2 { get; set; }
        public double M2 { get; set; }
        public int Ada { get; set; }
        public int Parcel { get; set; }
        public bool IsSold { get; set; }
        public int CategoryId { get; set; }
        public int ProductDetailId { get; set; }
        public CategoryViewModel Category { get; set; }
        public ProductDetailViewModel ProductDetail { get; set; }
        public List<ProductLikeViewModel> Products { get; set; }
        public List<CartItemViewModel> CartItems { get; set; }
    }
}
