using System.Web.Mvc;

namespace Svc.Web.Controllers
{
    public class HomeController : SvcControllerBase
    {
        public ActionResult Index()
        {
            return View("~/App/Main/views/layout/layout.cshtml"); //Layout of the angular application.
        }
	}
}