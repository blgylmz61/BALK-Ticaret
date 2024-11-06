using AutoMapper;
using BLL.AbstractServices;
using BLL.Dtos;
using DAL.AbstractRepository;
using DAL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ConcreteServices
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepository<Category> _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(IRepository<Category>categoryRepository,IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        public async Task CreateCategory(CategoryDto categoryDto)
        {
            await _categoryRepository.AddAsync(_mapper.Map<Category>(categoryDto));
        }

        public async Task DeleteCategory(int categoryId)
        {
            await _categoryRepository.DeleteAsync(categoryId);
        }

        public async Task<List<CategoryDto>> GetAllCategory()
        {
            var allCategories=await _categoryRepository.GetAllAsync();
            return (_mapper.Map<List<CategoryDto>>(allCategories));
        }

        public async Task<CategoryDto> GetCategoryById(int categoryId)
        {
            var category=await _categoryRepository.GetByIdAsync(categoryId);
            return(_mapper.Map<CategoryDto>(category));
        }

        public async Task UpdateCategory(CategoryDto categoryDto)
        {
            var category=await _categoryRepository.GetByIdAsync(categoryDto.Id);
            category.Name = categoryDto.Name;
            await _categoryRepository.UpdateAsync(category);
        }
    }
}
