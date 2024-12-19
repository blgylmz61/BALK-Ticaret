using AutoMapper;
using BLL.AbstractServices;
using BLL.Dtos;
using BLL.Helpers;
using DAL.AbstractRepository;
using DAL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ConcreteServices
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRepository;

        private readonly IMapper _mapper;
        public UserService(IRepository<User> userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
           public async Task<bool> CheckEmail(string email)
        {
            var users = await _userRepository.GetAllAsync();
            if (users != null)
            {
                var Email = users.Any(x => x.Email == email);
                return Email;
            }
            return false;
        }


        public async Task<bool> CheckUsername(string username)
        {
            var users = await _userRepository.GetAllAsync();
            if (users != null)
            {
                var Username = users.Any(x => x.Username == username);
                return Username;
            }
            return false;
        }

        public async Task CreateUser(UserDto userDto)
        {
            userDto.Name=StringHelper.CapitalizeFirstLetterOfEachWord(userDto.Name);
            userDto.Surname = StringHelper.CapitalizeFirstLetterOfEachWord(userDto.Surname);
            await _userRepository.AddAsync(_mapper.Map<User>(userDto));
        }

        public async Task DeleteUser(int userId)
        {
            await _userRepository.DeleteAsync(userId);
        }

        public async Task<List<UserDto>> GetAllUsers()
        {
            var users = await _userRepository.GetAllAsync();
            return _mapper.Map<List<UserDto>>(users);
        }

        public async Task<UserDto> GetUserId(int userId)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            return _mapper.Map<UserDto>(user);
        }

        public async Task<IEnumerable<UserDto>> GetUsersByConditionAsync(Expression<Func<UserDto, bool>> predicate)
        {
            var userPredicate = _mapper.Map<Expression<Func<User, bool>>>(predicate);
            var users = await _userRepository.FindAsync(userPredicate);
            return _mapper.Map<IEnumerable<UserDto>>(users);
        }

        public async Task<UserDto> GetUserWithDetail(int userId)
        {
            var user = await _userRepository.GetWithIncludeAsync(
                x => x.Id == userId,
                u => u.UserDetail,
                u => u.UserRole,
                u=>u.Cards,
                u=>u.UserDetail.Country,
                u => u.UserDetail.City,
                u => u.UserDetail.District);
            return _mapper.Map<UserDto>(user);
        }
        public async Task<List<UserDto>> GetAllUserWithDetail()
        {
            var users = await _userRepository.GetAllWithIncludeAsync(
                x =>true, 
                u => u.UserDetail, 
                u => u.UserRole, 
                u => u.Cards,
                u => u.UserDetail.Country, 
                u => u.UserDetail.City, 
                u => u.UserDetail.District,
                u => u.UserDetail.Gender);
            
            return _mapper.Map<List<UserDto>>(users);
        }

        public async Task<UserDto> Login(string username, string password)
        {
            var user = await _userRepository.GetWithIncludeAsync(
                x => x.Username == username && x.Password == password,
                u => u.UserDetail,
                u => u.UserRole,
                u => u.Cards); ;
            
            return _mapper.Map<UserDto>(user);
        }

        public async Task<List<UserDto>> Search(string username)
        {
            var users = await _userRepository.GetAllAsync();
            var SearchUser = new List<UserDto>();
            foreach (var user in users)
            {
                if (user.Username.Contains(username))
                {

                    SearchUser.Add(_mapper.Map<UserDto>(user));
                }
            }
            return SearchUser;
        }

        public async Task UpdateUser(UserDto userDto)
        {
            var user = await _userRepository.GetByIdAsync(userDto.Id);
            user.Name =StringHelper.CapitalizeFirstLetterOfEachWord( userDto.Name);
            user.Email = userDto.Email;
            user.Surname =StringHelper.CapitalizeFirstLetterOfEachWord( userDto.Surname);
            user.Password = userDto.Password;
            user.Username = userDto.Username;
            user.UserDetailId = userDto.UserDetailId;
            user.UserRoleId = userDto?.UserRoleId ?? user.UserRoleId;
            await _userRepository.UpdateAsync(user);
        }
    }
}
