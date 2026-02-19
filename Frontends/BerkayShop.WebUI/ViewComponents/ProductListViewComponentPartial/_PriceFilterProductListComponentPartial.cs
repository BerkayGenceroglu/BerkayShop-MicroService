using Microsoft.AspNetCore.Mvc;

namespace BerkayShop.WebUI.ViewComponents.ProductListViewComponentPartial
{
    public class _PriceFilterProductListComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
