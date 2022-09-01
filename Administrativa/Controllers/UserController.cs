using Logic.BLL.DTOS;
using Logic.BLL.Intefaces.Services;
using Logic.BLL.Services;
using Logic.BLL.ViewModels;
using Newtonsoft.Json;
using System;
using System.Web.Mvc;

namespace Administrativa.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService = new UserService();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(UserViewModel request)
        {
            try
            {
                _userService.AddUser(request);
                return Json(Url.Action("Index", "User"));
            }
            catch (Exception ex)
            {
                return Json(ex);

            }
        }

        [HttpPost]
        public ActionResult Update(UserViewModel request)
        {
            try
            {
                _userService.UpdateUser(request);
                return Json(Url.Action("Index", "User"));

            }
            catch (Exception ex)
            {
                return Json(ex);

            }
        }
       
        [HttpPost]
        public ActionResult Delete(UserViewModel request)
        {
            try
            {
                _userService.DeleteUser(request.ID);
                return Json(Url.Action("Index", "User"));

            }
            catch (Exception ex)
            {
                return Json(ex);

            }
        }
        public ActionResult List()
        {
            try
            {
                var result = _userService.GetAllProduct();
                var json = JsonConvert.SerializeObject(result);
                return Json(json, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }
        public JsonResult GetID(ProductsViewModel request)
        {
            try
            {
                var result = _userService.GetUserById(request.ID);
                var json = JsonConvert.SerializeObject(result);
                return Json(json, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }
    }
}
