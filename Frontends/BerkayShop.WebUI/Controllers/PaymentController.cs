using Microsoft.AspNetCore.Mvc;

namespace BerkayShop.WebUI.Controllers
{
    public class PaymentController : Controller
    {
        public IActionResult PaymentPage()
        {
            ViewBag.Directory1 = "BerkayShop";
            ViewBag.Directory2 = "Ödeme";
            ViewBag.Directory3 = "Kredi/Banka Kartı";
            return View();
        }
    }
}
