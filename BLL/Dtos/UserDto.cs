using DAL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Dtos
{
    public class UserDto:BaseEntityDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        public int UserRoleId { get; set; }
        public int UserDetailId { get; set; }
        public UserRoleDto UserRoleDto { get; set; }
        public UserDetailDto UserDetailDto { get; set; }
        public List<ProductLikeDto> ProductLikeDtos { get; set; }
        public Cart Cart { get; set; }
        public List<OrderDto> OrderDtos { get; set; }
        public List<CardDto> CardDtos { get; set; }

    }
}
