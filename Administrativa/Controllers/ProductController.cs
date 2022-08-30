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
                return Json(ex.Message);
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
                return RedirectToRoute(new {controller="Product", action="Index" }) ;
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }

        public ActionResult Update()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Update(ProductsViewModel request)
        {
            try
            {
                _productService.UpdateProduct(request);
                return RedirectToRoute(new { controller = "Product", action = "Index" });
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }


    }
}
