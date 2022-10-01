using Logic.BLL.DTOS;
using Logic.BLL.Intefaces.Services;
using Logic.BLL.Services;
using Newtonsoft.Json;
using System;
using System.Web.Mvc;

namespace Administrativa.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService = new CategoryService();
        public ActionResult Index()
        {
            return View();

        }
        public JsonResult List()
        {
            try
            {
                var result = _categoryService.GetAllCategory();
                var json = JsonConvert.SerializeObject(result);
                return Json(json,JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                UserViewModel user = new UserViewModel();
                user.HasError = true;
                user.Error = ex.Message;
                return Json(user);
            }
        }
        public JsonResult GetID(CategoryViewModel request)
        {
            try
            {
                var result = _categoryService.GetByIdCategory(request.ID);
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
        public ActionResult Create(CategoryViewModel request)
        {
            try
            {
                _categoryService.AddCategory(request);
                return Json(Url.Action("Index", "Category"));
            }
            catch (Exception ex)
            {
                request.HasError = true;
                request.Error = ex.Message;
                return Json(request);
            }
        }
        [HttpPost]
        public ActionResult Update(CategoryViewModel request)
        {
            try
            {
                _categoryService.UpdateCategory(request);
                return Json(Url.Action("Index", "Category"));
            }
            catch (Exception ex)
            {
                request.HasError = true;
                request.Error = ex.Message;
                return Json(request);
            }
        }

        [HttpPost]
        public ActionResult Delete(CategoryViewModel category)
        {
            try
            {
                _categoryService.DeleteCategory(category.ID);
                return Json(Url.Action("Index", "Category"));
            }
            catch (Exception ex)
            {
                category.HasError = true;
                category.Error = ex.Message;
                return Json(category);
            }
        }
    }
}
