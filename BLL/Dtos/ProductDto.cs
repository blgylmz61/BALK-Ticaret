using DAL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Dtos
{
    public class ProductDto : BaseEntityDto
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public List<string> Photos { get; set; }  // Kaydedilen dosya isimlerini tutmak için
        public int LikeCount { get; set; }
        public string? Description { get; set; }
        public decimal UnitPriceM2 { get; set; }
        public double M2 { get; set; }
        public int Ada { get; set; }
        public int Parcel { get; set; }
        public bool IsSold { get; set; }
        public int CategoryId { get; set; }
        public int ProductDetailId { get; set; }
        public CategoryDto Category { get; set; }
        public ProductDetailDto ProductDetail { get; set; }
        public List<ProductLikeDto> ProductLike { get; set; }
        public List<CartItemDto> CartItem { get; set; }

    }
}
