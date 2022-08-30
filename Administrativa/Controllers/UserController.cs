using Logic.BLL.DTOS;
using Logic.BLL.Intefaces.Services;
using Logic.BLL.Services;
using Logic.BLL.ViewModels;
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

        [HttpPut]
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
       
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            try
            {
                _userService.DeleteUser(id);
                return Json(Url.Action("Index", "User"));

            }
            catch (Exception ex)
            {
                return Json(ex);

            }
        }
    }
}
