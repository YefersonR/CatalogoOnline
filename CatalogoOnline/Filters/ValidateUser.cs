using CatalogoOnline.Controllers;
using Logic.BLL.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CatalogoOnline.Filters
{
    public class ValidateUser : ActionFilterAttribute
    {
        private UserViewModel _user;
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            try
            {
                base.OnActionExecuting(filterContext);
                _user = (UserViewModel)HttpContext.Current.Session["user"];
                if(_user == null) 
                {
                    if(filterContext.Controller is UserController == false)
                    {
                        filterContext.HttpContext.Response.Redirect("/User/Index");

                    }
                }

            }
            catch(Exception)
            {
                filterContext.Result = new RedirectResult("~/User/Index");
            }
        }
    }
}
