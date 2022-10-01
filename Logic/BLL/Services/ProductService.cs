using DataLayer.Repositories;
using Logic.BLL.DTOS;
using Logic.BLL.Intefaces.Repository;
using Logic.BLL.Intefaces.Services;
using Logic.DAL.Entities;
using System.Collections.Generic;
using System.Linq;


namespace Logic.BLL.Services
{
    public class ProductService : IProductsService
    {
        private readonly IProductRepository _productRepository = new ProductRepository();
        public void AddProduct(ProductsViewModel request) 
        {
            Product product = new Product
            {
                ProductName = request.ProductName,
                UnitPrice = request.UnitPrice,
                UnitInStock = request.UnitInStock,
                Garantie = request.Garantie,
                Discontinued = request.Discontinued,
                CategoryID = request.CategoryID,
                HasError = request.HasError,
                Error = request.Error
            };
            _productRepository.CreateProduct(product);
        }
        public void UpdateProduct(ProductsViewModel request)
        {
            Product product = new Product
            {
                ID=request.ID,
                ProductName = request.ProductName,
                UnitPrice = request.UnitPrice,
                UnitInStock = request.UnitInStock,
                Garantie = request.Garantie,
                Discontinued = request.Discontinued,
                CategoryID = request.CategoryID,
                HasError = request.HasError,
                Error = request.Error

            };
            _productRepository.UpdateProduct(product);
        }
        public void DeleteProduct(int Id)
        {
            _productRepository.DeleteProduct(Id);
        }
        public List<ProductsViewModel> GetAllProduct()
        {
            var products = _productRepository.GetProduct();
            List<ProductsViewModel> productsRequest = products.Select(request => new ProductsViewModel
            {
                ID = request.ID,
                ProductName = request.ProductName,
                UnitPrice = request.UnitPrice,
                UnitInStock = request.UnitInStock,
                Garantie = request.Garantie,
                Discontinued = request.Discontinued,
                HasError = request.HasError,
                Error = request.Error
            }).ToList();

            return productsRequest;
        }
        public List<ProductsViewModel> GetActiveProduct()
        {
            var products = _productRepository.GetActiveProduct();
            List<ProductsViewModel> productsRequest = products.Select(request => new ProductsViewModel
            {
                ID = request.ID,
                ProductName = request.ProductName,
                UnitPrice = request.UnitPrice,
                UnitInStock = request.UnitInStock,
                Garantie = request.Garantie,
                Discontinued = request.Discontinued,
                HasError = request.HasError,
                Error = request.Error
            }).ToList();

            return productsRequest;
        }


        public List<ProductsViewModel> SearchProducts(string search)
        {
            var products = _productRepository.SearchProduct(search);
            List<ProductsViewModel> productsRequest = products.Select(request => new ProductsViewModel
            {
                ID = request.ID,
                ProductName = request.ProductName,
                UnitPrice = request.UnitPrice,
                UnitInStock = request.UnitInStock,
                Garantie = request.Garantie,
                Discontinued = request.Discontinued,
                HasError = request.HasError,
                Error = request.Error
            }).ToList();

            return productsRequest;
        }
        public List<ProductsViewModel> FilterByCategory(int CategoryId)
        {
            var products = _productRepository.FilterByCategory(CategoryId);
            List<ProductsViewModel> productsRequest = products.Select(request => new ProductsViewModel
            {
                ID = request.ID,
                ProductName = request.ProductName,
                UnitPrice = request.UnitPrice,
                UnitInStock = request.UnitInStock,
                Garantie = request.Garantie,
                Discontinued = request.Discontinued,
                HasError = request.HasError,
                Error = request.Error
            }).ToList();

            return productsRequest;
        }

        public ProductsViewModel GetProductById(int Id)
        {
            var product = _productRepository.GetProductById(Id);
            ProductsViewModel productR = new ProductsViewModel
            {
                ID = product.ID,
                ProductName = product.ProductName,
                UnitPrice = product.UnitPrice,
                UnitInStock = product.UnitInStock,
                Garantie = product.Garantie,
                Discontinued = product.Discontinued,
                HasError = product.HasError,
                Error = product.Error
            };
            return productR;
        }
    }
}
