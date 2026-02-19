using Microsoft.AspNetCore.Mvc;

namespace BerkayShop.WebUI.ViewComponents.UILayoutViewComponentPartial
{
    public class _HeadUILayoutComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
