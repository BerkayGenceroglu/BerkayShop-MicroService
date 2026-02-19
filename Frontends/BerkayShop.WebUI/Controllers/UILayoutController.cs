using Microsoft.AspNetCore.Mvc;

namespace BerkayShop.WebUI.Controllers
{
    public class UILayoutController : Controller
    {
        public IActionResult _UILayout()
        {
            return View();
        }
    }
}
