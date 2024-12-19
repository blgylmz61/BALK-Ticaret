using AutoMapper;
using BLL.AbstractServices;
using BLL.Dtos;
using BLL.Helpers;
using DAL.AbstractRepository;
using DAL.Entites;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ConcreteServices
{
    public class UserRoleService : IUserRoleService
    {

        private readonly IRepository<UserRole> _userRoleRepositry;
        private readonly IMapper _mapper;

        public UserRoleService(IRepository<UserRole> userRoleRepositry, IMapper mapper)
        {
            _userRoleRepositry = userRoleRepositry;
            _mapper = mapper;
        }
        public async Task CreateUserRole(UserRoleDto userRoleDto)
        {
            if (userRoleDto != null)
            {
                userRoleDto.Role=StringHelper.CapitalizeFirstLetterOfEachWord(userRoleDto.Role);
                userRoleDto.Description=StringHelper.StringToTitleCase(userRoleDto.Description);
                await _userRoleRepositry.AddAsync(_mapper.Map<UserRole>(userRoleDto));
            }

        }

        public async Task DeleteUserRole(int userRoleId)
        {
            await _userRoleRepositry.DeleteAsync(userRoleId);
        }

        public async Task<List<UserRoleDto>> GetUserRoleAll()
        {
            var userRoles = await _userRoleRepositry.GetAllAsync();
            return (_mapper.Map<List<UserRoleDto>>(userRoles));
        }

        public async Task<UserRoleDto> GetUserRoleById(int userRoleId)
        {
            var userRole = await _userRoleRepositry.GetByIdAsync(userRoleId);
            return _mapper.Map<UserRoleDto>(userRole);
        }

        public async Task<IEnumerable<UserRoleDto>> GetUserRoleByUserId(int userRoleId)
        {
            var userRole = await _userRoleRepositry.FindAsync(x => x.Id == userRoleId);
            return _mapper.Map<IEnumerable<UserRoleDto>>(userRole);
        }

        public async Task UpdateUserRole(UserRoleDto userRoleDto)
        {
            var userRole = await _userRoleRepositry.GetByIdAsync(userRoleDto.Id);
            userRoleDto.Role =StringHelper.CapitalizeFirstLetterOfEachWord( userRoleDto.Role);
            var UserRole=_mapper.Map<UserRole>(userRole);
            await _userRoleRepositry.UpdateAsync(UserRole);
        }
    }
}
