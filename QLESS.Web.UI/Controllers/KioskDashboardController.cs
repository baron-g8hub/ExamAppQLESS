using Microsoft.AspNetCore.Mvc;

namespace QLESS.Web.UI.Controllers
{
    public class KioskDashboardController : Controller
    {


        public IActionResult Index()
        {
            return View();
        }
    }
}
