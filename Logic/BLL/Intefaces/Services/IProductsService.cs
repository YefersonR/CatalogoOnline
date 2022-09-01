using Logic.BLL.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.BLL.Intefaces.Services
{
    public interface IProductsService
    {
        ProductsViewModel GetProductById(int Id);
        List<ProductsViewModel> FilterByCategory(int CategoryId);
        List<ProductsViewModel> SearchProducts(string search);
        List<ProductsViewModel> GetAllProduct();
        void DeleteProduct(int Id);
        void UpdateProduct(ProductsViewModel request);
        void AddProduct(ProductsViewModel request);
        List<ProductsViewModel> GetActiveProduct();
    }
}
