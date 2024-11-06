using DAL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Dtos
{
    public class CommentDto : BaseEntityDto
    {
        public int UserId { get; set; }
        public UserDto UserDto { get; set; }
        public int ProductId { get; set; }
        public ProductDto ProductDto { get; set; }
        public string Description { get; set; }
        public int Scor { get; set; }
    }
}
