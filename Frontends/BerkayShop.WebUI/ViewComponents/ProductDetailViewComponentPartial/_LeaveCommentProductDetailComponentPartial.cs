using Microsoft.AspNetCore.Mvc;

namespace BerkayShop.WebUI.ViewComponents.ProductDetailViewComponentPartial
{
    public class _LeaveCommentProductDetailComponentPartial: ViewComponent
    {
        public IViewComponentResult Invoke(string productId)
        {
            ViewBag.ProductId = productId;
            return View();
        }
    }
}
