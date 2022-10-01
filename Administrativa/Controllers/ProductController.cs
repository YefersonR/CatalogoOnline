using Logic.BLL.DTOS;
using Logic.BLL.Intefaces.Services;
using Logic.BLL.Services;
using Newtonsoft.Json;
using System;
using System.Web.Mvc;

namespace Administrativa.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductsService _productService = new ProductService();

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
                UserViewModel user = new UserViewModel();
                user.HasError = true;
                user.Error = ex.Message;
                return Json(user);
            }
        }
        public JsonResult GetID(ProductsViewModel request)
        {
            try
            {
                var result = _productService.GetProductById(request.ID);
                var json = JsonConvert.SerializeObject(result);
                return Json(json, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                request.HasError = true;
                request.Error = ex.Message;
                return Json(request);
            }
        }

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
                return Json(Url.Action("Index", "Product"));
            }
            catch (Exception ex)
            {
                request.HasError = true;
                request.Error = ex.Message;
                return Json(request);
            }
        }

        [HttpPost]
        public ActionResult Update(ProductsViewModel request)
        {
            try
            {
                _productService.UpdateProduct(request);
                return Json(Url.Action("Index", "Product"));
            }
            catch (Exception ex)
            {
                request.HasError = true;
                request.Error = ex.Message;
                return Json(request);
            }
        }
        [HttpPost]
        public ActionResult Delete(ProductsViewModel product)
        {
            try
            {
                _productService.DeleteProduct(product.ID);
                return Json(Url.Action("Index", "Product"));
            }
            catch (Exception ex)
            {
                product.HasError = true;
                product.Error = ex.Message;
                return Json(product);
            }
        }


    }
}
