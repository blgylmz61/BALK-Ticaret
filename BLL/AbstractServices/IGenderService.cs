using BLL.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.AbstractServices
{
    public interface IGenderService
    {
        Task CreateGender(GenderDto genderDto);
        Task DeleteGender(int genderId);
        Task UpdateGender(GenderDto genderDto);
        Task<GenderDto> GetGenderById(int genderId);
        Task<List<GenderDto>> GetAllGender();
    }
}
