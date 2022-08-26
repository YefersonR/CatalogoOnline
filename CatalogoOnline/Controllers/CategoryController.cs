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
    public class CategoryController : Controller
    {
        private readonly CategoryService _categoryService = new CategoryService();
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
        public ActionResult Create(CategoryRequest request)
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
        [HttpPut]
        public ActionResult Update(CategoryRequest request)
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
