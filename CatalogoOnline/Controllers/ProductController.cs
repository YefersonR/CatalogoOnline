using BusinessLayer.DTOS;
using BusinessLayer.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Mvc;

namespace CatalogoOnline.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductService _productService = new ProductService();

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(ProductsRequest request)
        {
            try
            {
                _productService.AddProduct(request);
                return RedirectToRoute(new {controller="Product", action="Index" }) ;
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }
        [HttpPut]
        public ActionResult Update(ProductsRequest request)
        {
            try
            {
                
                _productService.UpdateProduct(request);
                return View();
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            try
            {
                var result = _productService.GetAllProduct();
                var json = JsonConvert.SerializeObject(result);
                return Json(json, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }

        public ActionResult Search(string search)
        {
            try
            {
                List<ProductsRequest> result = new List<ProductsRequest>();
                string json = "";
                if (search == " " || search == null)
                {
                    result = _productService.GetAllProduct();
                }
                else
                {
                    result = _productService.SearchProducts(search);
                }
                json = JsonConvert.SerializeObject(result);
                return Json(json, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }

        public ActionResult FilterByCategory(int CategoryId)
        {
            try
            {
                List<ProductsRequest> result = new List<ProductsRequest>();
                string json = ""; 
                if (CategoryId == 0)
                {
                    result = _productService.GetAllProduct();
                }
                else
                {
                    result = _productService.FilterByCategory(CategoryId);
                }
                    json = JsonConvert.SerializeObject(result);
                    return Json(json, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }

        [HttpGet]
        public ActionResult GetById(int id)
        {
            try
            {
                var result =  _productService.GetProductById(id);
                return View(result);
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            try
            {
                _productService.DeleteProduct(id);
                return View();
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }

    }
}
