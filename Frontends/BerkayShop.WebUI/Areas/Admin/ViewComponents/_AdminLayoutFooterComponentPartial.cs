using Microsoft.AspNetCore.Mvc;

namespace BerkayShop.WebUI.Areas.Admin.ViewComponents
{
    public class _AdminLayoutFooterComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
