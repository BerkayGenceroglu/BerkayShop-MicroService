using Microsoft.AspNetCore.Mvc;

namespace BerkayShop.WebUI.ViewComponents.ContactViewComponentPartial
{
    public class _FormContactComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
