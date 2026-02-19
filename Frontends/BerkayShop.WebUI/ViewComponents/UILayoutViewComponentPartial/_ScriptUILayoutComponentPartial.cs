using Microsoft.AspNetCore.Mvc;

namespace BerkayShop.WebUI.ViewComponents.UILayoutViewComponentPartial
{
    public class _ScriptUILayoutComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
