using Microsoft.AspNetCore.Mvc;

namespace BerkayShop.WebUI.Controllers
{
    public class InformationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
