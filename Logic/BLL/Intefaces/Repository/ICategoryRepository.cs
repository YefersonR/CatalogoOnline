using Logic.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.BLL.Intefaces.Repository
{
    public interface ICategoryRepository
    {
        void CreateCategory(Category category);
        void UpdateCategory(Category category);
        void DeleteCategory(int Id);
        List<Category> GetCategory();
        Category GetById(int Id);
        List<Category> GetActiveCategory();
    }
}
