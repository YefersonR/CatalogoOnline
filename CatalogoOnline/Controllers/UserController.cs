using BusinessLayer.DTOS;
using BusinessLayer.Services;
using BusinessLayer2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace CatalogoOnline.Controllers
{
    public class UserController : Controller
    {
        private readonly UserService _userService = new UserService();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register( )
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(UserRequest request)
        {
            try
            {
                _userService.AddUser(request);
                return View(request);
            }
            catch (Exception ex)
            {
                return Json(ex);

            }
        }

        [HttpPost]
        public ActionResult Login(LoginRequest request)
        {
            try
            {
               var user = _userService.Login(request);
                if (user != null)
                {
                    return RedirectToRoute(new {controller="Home",action="Index" });
                }
                return View(request);
            }
            catch (Exception ex)
            {
                return Json(ex);

            }
        }
        [HttpPut]
        public ActionResult Update(UserRequest request)
        {
            try
            {
                _userService.UpdateUser(request);
                return View(request);

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
                return View();

            }
            catch (Exception ex)
            {
                return Json(ex);

            }
        }
    }
}
