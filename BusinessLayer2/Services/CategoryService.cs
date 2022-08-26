using BusinessLayer.DTOS;
using DataLayer.Entities;
using DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class CategoryService
    {
        private readonly CategoryRepository _categoryRepository = new CategoryRepository();
        public void AddCategory(CategoryRequest request)
        {
            Category category = new Category
            {
                CategoryName = request.CategoryName,
                CategoryDescription = request.CategoryDescription,
                IsActive = request.IsActive
            };
            _categoryRepository.CreateCategory(category);
        }
        public void UpdateCategory(CategoryRequest request)
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
        public List<CategoryRequest> GetAllCategory()
        {
            var category = _categoryRepository.GetCategory();
            List<CategoryRequest> categoryResquest = category.Select(request=>new CategoryRequest
            {
                ID = request.ID,
                CategoryName = request.CategoryName,
                CategoryDescription = request.CategoryDescription,
                IsActive = request.IsActive
            }).ToList();

            return categoryResquest;
        }
    }
}
