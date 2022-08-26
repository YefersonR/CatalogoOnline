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
    public class ProductService
    {
        private readonly ProductRepository _productRepository = new ProductRepository();
        public void AddProduct(ProductsRequest request)
        {
            Product product = new Product
            {
                ProductName = request.ProductName,
                UnitPrice = request.UnitPrice,
                UnitInStock = request.UnitInStock,
                Garantie = request.Garantie,
                Discontinued = request.Discontinued,
                CategoryID = request.CategoryID
            };
            _productRepository.CreateProduct(product);
        }
        public void UpdateProduct(ProductsRequest request)
        {
            Product product = new Product
            {
                ID=request.ID,
                ProductName = request.ProductName,
                UnitPrice = request.UnitPrice,
                UnitInStock = request.UnitInStock,
                Garantie = request.Garantie,
                Discontinued = request.Discontinued,
                CategoryID = request.CategoryID

            };
            _productRepository.UpdateProduct(product);
        }
        public void DeleteProduct(int Id)
        {
            _productRepository.DeleteProduct(Id);
        }
        public List<ProductsRequest> GetAllProduct()
        {
            var products = _productRepository.GetProduct();
            List<ProductsRequest> productsRequest = products.Select(request => new ProductsRequest
            {
                ID = request.ID,
                ProductName = request.ProductName,
                UnitPrice = request.UnitPrice,
                UnitInStock = request.UnitInStock,
                Garantie = request.Garantie,
                Discontinued = request.Discontinued
            }).ToList();

            return productsRequest;
        }

        public List<ProductsRequest> SearchProducts(string search)
        {
            var products = _productRepository.SearchProduct(search);
            List<ProductsRequest> productsRequest = products.Select(request => new ProductsRequest
            {
                ID = request.ID,
                ProductName = request.ProductName,
                UnitPrice = request.UnitPrice,
                UnitInStock = request.UnitInStock,
                Garantie = request.Garantie,
                Discontinued = request.Discontinued
            }).ToList();

            return productsRequest;
        }
        public List<ProductsRequest> FilterByCategory(int CategoryId)
        {
            var products = _productRepository.FilterByCategory(CategoryId);
            List<ProductsRequest> productsRequest = products.Select(request => new ProductsRequest
            {
                ID = request.ID,
                ProductName = request.ProductName,
                UnitPrice = request.UnitPrice,
                UnitInStock = request.UnitInStock,
                Garantie = request.Garantie,
                Discontinued = request.Discontinued
            }).ToList();

            return productsRequest;
        }

        public ProductsRequest GetProductById(int Id)
        {
            var product = _productRepository.GetProductById(Id);
            ProductsRequest productR = new ProductsRequest
            {
                ID = product.ID,
                ProductName = product.ProductName,
                UnitPrice = product.UnitPrice,
                UnitInStock = product.UnitInStock,
                Garantie = product.Garantie,
                Discontinued = product.Discontinued
            };
            return productR;
        }
    }
}
