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
    public class UserDetailService : IUserDetailService
    {
        private readonly IRepository<UserDetail> _userDetailRepository;
        private readonly IMapper _mapper;

        public UserDetailService(IRepository<UserDetail> userDetailRepository, IMapper mapper)
        {
            _userDetailRepository = userDetailRepository;
            _mapper = mapper;
        }
        public async Task CreateUserDetail(UserDetailDto userDetailDto)
        {
            await _userDetailRepository.AddAsync(_mapper.Map<UserDetail>(userDetailDto));
        }
        public async Task<List<UserDetailDto>> GetAllUserDetailWithDetails()
        {
            var userDetails = await _userDetailRepository.GetAllWithIncludeAsync(x =>true, p => p.City, p => p.Country, p => p.District, p => p.Gender);
            return _mapper.Map<List<UserDetailDto>>(userDetails);
        }

        public async Task<UserDetailDto> GetUserDetailWithDetails(int userDetailId)
        {
            var userDetail = await _userDetailRepository.GetWithIncludeAsync(x => x.Id == userDetailId, p => p.City, p => p.Country, p => p.District, p => p.Gender);
            return _mapper.Map<UserDetailDto>(userDetail);
        }

        public async Task DeleteUserDetail(int userDetailId)
        {
            await _userDetailRepository.DeleteAsync(userDetailId);
        }

        public async Task<List<UserDetailDto>> GetUserDetailAll()
        {
            var userDetails = await _userDetailRepository.GetAllAsync();
            return _mapper.Map<List<UserDetailDto>>(userDetails);
        }

        public async Task<UserDetailDto> GetUserDetailById(int userDetailId)
        {
            var userDetail = await _userDetailRepository.GetWithIncludeAsync(x => x.Id == userDetailId, p => p.City, p => p.Country, p => p.District, p => p.Gender);
            userDetail.Country.Name = StringHelper.CapitalizeFirstLetterOfEachWord(userDetail.Country.Name);
            userDetail.City.Name = StringHelper.CapitalizeFirstLetterOfEachWord(userDetail.City.Name);
            userDetail.District.Name = StringHelper.CapitalizeFirstLetterOfEachWord(userDetail.District.Name);

            return _mapper.Map<UserDetailDto>(userDetail);
        }

        public async Task UpdateUserDetail(UserDetailDto userDetailDto)
        {
            var userDetail = await _userDetailRepository.GetByIdAsync(userDetailDto.Id);
            userDetail.Birthday = userDetailDto.Birthday;
            userDetail.Address =StringHelper.CapitalizeFirstLetterOfEachWord( userDetailDto.Address);
            userDetail.Phone = userDetailDto.Phone;
            userDetail.TcNo = userDetailDto.TcNo;
            userDetail.Photo = userDetailDto.Photo;
            userDetail.GenderId = userDetailDto.GenderId;
            userDetail.CountryId = userDetailDto.CountryId;
            userDetail.CityId = userDetailDto.CityId;
            userDetail.DistrictId = userDetailDto.DistrictId;
            await _userDetailRepository.UpdateAsync(userDetail);
        }

        public async Task<bool> CheckTcNo(string TcNo)
        {
            var userDetails = await _userDetailRepository.GetAllAsync();
            if (userDetails != null)
            {
                var Tcno = userDetails.Any(x => x.TcNo == TcNo);
                return Tcno;
            }
            return false;

        }

        public async Task<IEnumerable<UserDetailDto>> GetUserDetailByConditionAsync(Expression<Func<UserDetailDto, bool>> predicate)
        {
            var userDetailPredicate = _mapper.Map<Expression<Func<UserDetail, bool>>>(predicate);
            var userDetails = await _userDetailRepository.FindAsync(userDetailPredicate);
            return _mapper.Map<IEnumerable<UserDetailDto>>(userDetails);
        }

    }
}
