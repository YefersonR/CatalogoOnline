using System.Web.Mvc;

namespace CatalogoOnline.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var user = Session["user"];
            if (user != null)
            {
                ViewBag.user = Session["user"];
                return View();

            }
            return RedirectToRoute(new { controller = "User", action = "Index" });
        }
    }
}