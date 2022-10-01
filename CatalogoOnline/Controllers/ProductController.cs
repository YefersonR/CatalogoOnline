using Logic.BLL.DTOS;
using Logic.BLL.Intefaces.Services;
using Logic.BLL.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace CatalogoOnline.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductsService _productService = new ProductService();
        private readonly ICategoryService _categoryService = new CategoryService();

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(ProductsViewModel request)
        {    
            try
            {
                _productService.AddProduct(request);
                return Json(Url.Action("Index", "Home"));
            }
            catch (Exception ex)
            {
                request.HasError = true;
                request.Error = ex.Message;
                return Json(request);
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
                var result = _productService.GetActiveProduct();
                var json = JsonConvert.SerializeObject(result);
                return Json(json, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                UserViewModel request = new UserViewModel();
                request.HasError = true;
                request.Error = ex.Message;
                return Json(request);
            }
        }

        public JsonResult ListCategory()
        {
            try
            {
                var result = _categoryService.GetActiveCategory();
                var json = JsonConvert.SerializeObject(result);
                return Json(json, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                UserViewModel request = new UserViewModel();
                request.HasError = true;
                request.Error = ex.Message;
                return Json(request);
            }
        }

        public ActionResult Search(string search)
        {   
            try
            {
                List<ProductsViewModel> result = new List<ProductsViewModel>();
                string json = "";
                if (search == " " || search == null)
                {
                    result = _productService.GetActiveProduct();
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
                UserViewModel request = new UserViewModel();
                request.HasError = true;
                request.Error = ex.Message;
                return Json(request);
            }
        }
        public ActionResult FilterByCategory(int CategoryId)
        {
            try
            {
                List<ProductsViewModel> result = new List<ProductsViewModel>();
                string json = ""; 
                if (CategoryId == 0)
                {
                    result = _productService.GetActiveProduct();
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
                UserViewModel request = new UserViewModel();
                request.HasError = true;
                request.Error = ex.Message;
                return Json(request);
            }
        }
    }
}
