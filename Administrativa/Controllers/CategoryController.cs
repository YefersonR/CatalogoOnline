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
                return View();
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }
        public ActionResult Update()
        {
            return View();
        }
        [HttpPut]
        public ActionResult Update(CategoryViewModel request)
        {
            try
            {
                _categoryService.UpdateCategory(request);
                return View();
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }
          

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            try
            {
                _categoryService.DeleteCategory(id);
                return View();
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }
    }
}
