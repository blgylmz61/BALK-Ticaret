using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entites
{
    public class Product : BaseEntity
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
        public Category Category { get; set; }
        public ProductDetail ProductDetail { get; set; }
        public List<ProductLike> ProductLikes { get; set; }
        public List<CartItem> CartItems { get; set; }



    }
}
