using AutoMapper;
using BLL.AbstractServices;
using BLL.Dtos;
using BLL.Helpers;
using DAL.AbstractRepository;
using DAL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ConcreteServices
{
    public class GenderService : IGenderService
    {
        private readonly IRepository<Gender> _genderRepository;
        private readonly IMapper _mapper;

        public GenderService(IRepository<Gender>genderRepository,IMapper mapper)
        {
            _genderRepository = genderRepository;
            _mapper = mapper;
        }
        public async Task CreateGender(GenderDto genderDto)
        {
            genderDto.Name =StringHelper.CapitalizeFirstLetterOfEachWord(genderDto.Name);
            await _genderRepository.AddAsync(_mapper.Map<Gender>(genderDto));
        }

        public async Task DeleteGender(int genderId)
        {
            await _genderRepository.DeleteAsync(genderId);
        }

        public async Task<List<GenderDto>> GetAllGender()
        {
            var genders=await _genderRepository.GetAllAsync();
            return (_mapper.Map<List<GenderDto>>(genders));
        }

        public async Task<GenderDto> GetGenderById(int genderId)
        {
            var gender=await _genderRepository.GetByIdAsync(genderId);
            return (_mapper.Map<GenderDto>(gender));
        }

        public async Task UpdateGender(GenderDto genderDto)
        {
           var updateGender=await _genderRepository.GetByIdAsync(genderDto.Id);
            updateGender.Name =StringHelper.CapitalizeFirstLetterOfEachWord( genderDto.Name); 
            await _genderRepository.UpdateAsync(updateGender);  
        }
    }
}
