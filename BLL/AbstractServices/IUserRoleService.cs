using BLL.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.AbstractServices
{
    public interface IUserRoleService
    {
        Task CreateUserRole(UserRoleDto userRoleDto); //kullanıcı rolü oluştur
        Task DeleteUserRole(int userRoleId);
        Task UpdateUserRole(UserRoleDto userRoleDto);
        Task<UserRoleDto> GetUserRoleById(int userRoleId);
        Task<List<UserRoleDto>> GetUserRoleAll();
        Task<IEnumerable<UserRoleDto>> GetUserRoleByUserId(int userRoleId);
    }
}
