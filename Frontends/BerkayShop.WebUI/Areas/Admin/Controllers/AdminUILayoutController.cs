using Microsoft.AspNetCore.Mvc;

namespace BerkayShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminUILayoutController : Controller
    {
        public IActionResult UILayout()
        {
            return View();
        }
    }
}
