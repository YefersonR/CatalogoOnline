using Logic.BLL.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.BLL.Intefaces.Services
{
    public interface ICategoryService
    {
        void AddCategory(CategoryViewModel request);
        void DeleteCategory(int Id);
        List<CategoryViewModel> GetAllCategory();
        void UpdateCategory(CategoryViewModel request);
        CategoryViewModel GetByIdCategory(int id);
    }
}
