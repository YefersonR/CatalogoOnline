using Logic.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.BLL.Intefaces.Repository
{
    public interface IProductRepository
    {
        void CreateProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(int Id);
        List<Product> GetProduct();
        List<Product> SearchProduct(string search);
        List<Product> FilterByCategory(int CategoryId);
        Product GetProductById(int Id);
    }
}
