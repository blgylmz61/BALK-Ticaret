using DAL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Dtos
{
    public class ProductLikeDto : BaseEntityDto
    {
        public int ProductId { get; set; }
        public ProductDto? Product { get; set; }
        public bool IsLike { get; set; }

        public int UserId { get; set; }
        public UserDto? User { get; set; }
    }
}
