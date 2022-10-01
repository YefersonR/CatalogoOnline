using Logic.BLL.DTOS;
using Logic.BLL.Intefaces.Services;
using Logic.BLL.Services;
using Logic.BLL.ViewModels;
using System;
using System.Web.Mvc;

namespace CatalogoOnline.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService = new UserService();
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel request)
        {
            try
            {
                var user = _userService.Login(request);
                if (user.ID != 0 || user == null)
                {
                    Session["user"] = user;
                    return Json(Url.Action("Index", "Home"));
                }
                return Json(Url.Action("Index", "User"));
            }
            catch (Exception ex)
            {
                request.HasError = true;
                request.Error = ex.Message;
                return Json(request);
            }
        }
        public ActionResult LogOut()
        {
            Session["user"] = null;
            return RedirectToRoute(new { controler="User",action="Index"});
        }
    }
}
