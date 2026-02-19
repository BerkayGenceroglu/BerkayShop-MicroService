using Microsoft.AspNetCore.Mvc;

namespace BerkayShop.WebUI.ViewComponents.ProductListViewComponentPartial
{
    public class _ColorFilterProductListComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
