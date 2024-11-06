using AutoMapper;
using BALK_Ticaret.Models;
using BLL.AbstractServices;
using BLL.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace BALK_Ticaret.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var allCategories=await _categoryService.GetAllCategory();
            if (allCategories != null)
            {
                return View(_mapper.Map<List<CategoryViewModel>>(allCategories));
            }
            return View();
        }

        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CategoryViewModel categoryViewModel)
        {
            if (categoryViewModel != null)
            {
                var categoryDto = _mapper.Map<CategoryDto>(categoryViewModel);
                await _categoryService.CreateCategory(categoryDto);
                return RedirectToAction("Index", "Category");
            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int categoryId)
        {
            await _categoryService.DeleteCategory(categoryId);
            return RedirectToAction("Index", "Category");
        }
        public async Task<IActionResult> Update(int categoryId)
        {
            var category = await _categoryService.GetCategoryById(categoryId);

            return View(_mapper.Map<CategoryViewModel>(category));
        }
        [HttpPost]
        public async Task<IActionResult> Update(CategoryViewModel categoryViewModel,int categoryId)
        {
            var category = await _categoryService.GetCategoryById(categoryId);
            category.Name = categoryViewModel.Name;
            await _categoryService.UpdateCategory(_mapper.Map<CategoryDto>(category));

          return RedirectToAction("Index", "Category");

        }
    }
}
