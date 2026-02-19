using Microsoft.AspNetCore.Mvc;

namespace BerkayShop.WebUI.ViewComponents.ProductListViewComponentPartial
{
    public class _SizeFilterProductListComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
