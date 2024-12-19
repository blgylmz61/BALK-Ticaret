using DAL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Dtos
{
    public class UserRoleDto:BaseEntityDto
    {
        public string Role { get; set; }
        public string Description { get; set; }
        public List<UserDto> Users { get; set; }
    }
}
