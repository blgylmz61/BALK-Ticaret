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
        public string ProductCode { get; set; }
        public string Name { get; set; }
        public string Photo { get; set; }
        public string Description { get; set; }
        public decimal UnitPriceM2 { get; set; }
        public decimal M2 { get; set; }
        public int Ada { get; set; }
        public int Parcel { get; set; }
        public bool IsSold { get; set; }
        public int CategoryId { get; set; }
        public int ProductDetailId { get; set; }
        public CategoryDto CategoryDto { get; set; }
        public ProductDetailDto ProductDetailDto { get; set; }
        public List<ProductLikeDto> ProductLikeDtos { get; set; }
        public List<CartItemDto> CartItemDtos { get; set; }

    }
}
