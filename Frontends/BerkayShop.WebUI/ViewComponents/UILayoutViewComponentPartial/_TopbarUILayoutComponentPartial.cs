using Microsoft.AspNetCore.Mvc;

namespace BerkayShop.WebUI.ViewComponents.UILayoutViewComponentPartial
{
    public class _TopbarUILayoutComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
