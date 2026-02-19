using Microsoft.AspNetCore.Mvc;

namespace BerkayShop.WebUI.ViewComponents.ProductListViewComponentPartial
{
    public class _PaginationProductListComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
           return View();
        }
    }
}
