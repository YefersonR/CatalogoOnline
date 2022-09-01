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
            var user = Session["user"];
            if (user != null)
            {
                return Json(Url.Action("Index", "Home"));
            }
            return Json(Url.Action("Index", "User"));
        }
        [HttpPost]
        public ActionResult Create(ProductsViewModel request)
        {
            var user = Session["user"];
            if (user != null)
            {
                try
                    {
                        _productService.AddProduct(request);
                        return Json(Url.Action("Index", "Home"));
                    }
                    catch (Exception ex)
                    {
                        return Json(ex.Message);
                    }
            }
            return Json(Url.Action("Index", "User"));

        }

        public ActionResult Index()
        {
            var user = Session["user"];
            if (user != null)
            {
                return View();
            }
            return Json(Url.Action("Index", "User"));
        }

        public ActionResult List()
        {
            var user = Session["user"];
            if (user != null)
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
            return Json(Url.Action("Index", "User"));

        }

        public JsonResult ListCategory()
        {
            try
            {
                var result = _categoryService.GetAllCategory();
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
            var user = Session["user"];
            if (user != null)
            {
                try
                {
                    List<ProductsViewModel> result = new List<ProductsViewModel>();
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
            return Json(Url.Action("Index", "User"));

        }

        public ActionResult FilterByCategory(int CategoryId)
        {
            var user = Session["user"];
            if (user != null)
            {
                try
                {
                    List<ProductsViewModel> result = new List<ProductsViewModel>();
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
            return Json(Url.Action("Index", "User"));

        }

    }
}
