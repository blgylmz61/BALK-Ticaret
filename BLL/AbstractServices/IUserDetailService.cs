using BLL.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL.AbstractServices
{
    public interface IUserDetailService
    {
        Task CreateUserDetail(UserDetailDto userDetailDto); //kullanıcı rolü oluştur
        Task DeleteUserDetail(int userDetailId);
        Task UpdateUserDetail(UserDetailDto userDetailDto);
        Task<UserDetailDto> GetUserDetailById(int userDetailId);
        Task<List<UserDetailDto>> GetUserDetailAll();
        Task<bool> CheckTcNo(string TcNo); //TcNo Kontrolu
       Task<IEnumerable<UserDetailDto>>GetUserDetailByConditionAsync(Expression<Func<UserDetailDto,bool>>predicate);
        Task<UserDetailDto> GetUserDetailWithDetails(int userDetailId);



    }
}
