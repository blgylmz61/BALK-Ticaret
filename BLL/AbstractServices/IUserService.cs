using BLL.Dtos;
using DAL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL.AbstractServices
{
    public interface IUserService
    {
        Task<UserDto> Login(string username, string password); //giriş
        Task<bool> CheckUsername(string username); //kullanıcı adı kontrolu
        Task<bool> CheckEmail(string email); //Email Kontrolu
        Task<UserDto> GetUserId(int userId); //Tek Kullanıcı getir
        Task CreateUser(UserDto userDto); //Kullanıcı oluştur
        Task<List<UserDto>> GetAllUsers(); //bütün Kullanıcıları getir
        Task DeleteUser(int userId); //Kullanıcı sil
        Task UpdateUser(UserDto userDto); //Kullanıcı Güncelle
        Task<List<UserDto>> Search(string searchedTerm); //Arama 
        Task<IEnumerable<UserDto>> GetUsersByConditionAsync(Expression<Func<UserDto, bool>> predicate);
        Task<UserDto> GetUserWithDetail(int userDetailId);





    }
}
