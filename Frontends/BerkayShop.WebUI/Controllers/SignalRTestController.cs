using Microsoft.AspNetCore.Mvc;

namespace BerkayShop.WebUI.Controllers
{
    public class SignalRTestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
