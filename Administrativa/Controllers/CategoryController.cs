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
                return Json(ex.Message);
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
                return Json(ex.Message);
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
                return Json(ex);
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
                return Json(ex);
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
                return Json(ex.Message);
            }
        }
    }
}
