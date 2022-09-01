using Logic.BLL.DTOS;
using Logic.BLL.Intefaces.Repository;
using Logic.BLL.Intefaces.Services;
using Logic.DAL.Entities;
using Logic.DAL.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Logic.BLL.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository = new CategoryRepository();
        public void AddCategory(CategoryViewModel request)
        {
            Category category = new Category
            {
                CategoryName = request.CategoryName,
                CategoryDescription = request.CategoryDescription,
                IsActive = request.IsActive
            };
            _categoryRepository.CreateCategory(category);
        }
        public void UpdateCategory(CategoryViewModel request)
        {
            Category category = new Category
            {
                ID = request.ID,
                CategoryName = request.CategoryName,
                CategoryDescription = request.CategoryDescription,
                IsActive = request.IsActive
            };
            _categoryRepository.UpdateCategory(category);
        }
        public void DeleteCategory(int Id)
        {
            _categoryRepository.DeleteCategory(Id);
        }
        public List<CategoryViewModel> GetAllCategory()
        {
            var category = _categoryRepository.GetCategory();
            List<CategoryViewModel> categoryResquest = category.Select(request=>new CategoryViewModel
            {
                ID = request.ID,
                CategoryName = request.CategoryName,
                CategoryDescription = request.CategoryDescription,
                IsActive = request.IsActive
            }).ToList();

            return categoryResquest;
        }
        public CategoryViewModel GetByIdCategory(int id)
        {
            var category = _categoryRepository.GetById(id);
            CategoryViewModel categoryResquest = new CategoryViewModel()
            {
                ID = category.ID,
                CategoryName = category.CategoryName,
                CategoryDescription = category.CategoryDescription,
                IsActive = category.IsActive
            };

            return categoryResquest;
        }
    }
}
