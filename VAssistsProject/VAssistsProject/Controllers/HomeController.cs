using System.Web.Mvc;

namespace VAssistsProject.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return new RedirectResult("~/swagger");
        }
    }
}