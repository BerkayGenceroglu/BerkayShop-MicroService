using BerkayShop.WebUI.Services.BasketServices;
using BerkayShop.WebUI.Services.DiscountServices;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace BerkayShop.WebUI.ViewComponents.ShoppingCartViewComponentPartial
{
    public class _CouponAndSummaryShoppingCartComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
