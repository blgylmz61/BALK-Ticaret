using BLL.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.AbstractServices
{
    public interface ICategoryService
    {
        Task CreateCategory(CategoryDto categoryDto); 
        Task DeleteCategory(int categoryId);
        Task UpdateCategory(CategoryDto categoryDto);
        Task<CategoryDto> GetCategoryById(int categoryId);
        Task<List<CategoryDto>> GetAllCategory();
    }
}
