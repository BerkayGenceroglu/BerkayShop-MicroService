using Microsoft.AspNetCore.Mvc;

namespace BerkayShop.WebUI.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult DefaultPage()
        {
            ViewBag.Directory1 = "BerkayShop";
            ViewBag.Directory2 = "Anasayfa";
            ViewBag.Directory3 = "Öne Çıkanlar";
            return View();
        }
    }
}
