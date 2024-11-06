using DAL.Entites;

namespace BALK_Ticaret.Models
{
    public class ProductViewModel : BaseEntityViewModel
    {
        public string ProductCode { get; set; }
        public string Name { get; set; }
        public string Photo { get; set; }
        public IFormFile? PhotoUrl { get; set; }
        public string Description { get; set; }
        public decimal UnitPriceM2 { get; set; }
        public decimal M2 { get; set; }
        public int Ada { get; set; }
        public int Parcel { get; set; }
        public bool IsSold { get; set; }
        public int CategoryId { get; set; }
        public int ProductDetailId { get; set; }
        public CategoryViewModel CategoryViewModel { get; set; }
        public ProductDetailViewModel ProductDetailViewModel { get; set; }
        public List<ProductLikeViewModel> ProductLikeViewModels { get; set; }
        public List<CartItemViewModel> CartItemViewModels { get; set; }
    }
}
