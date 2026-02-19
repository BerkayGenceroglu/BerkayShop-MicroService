using BerkayShop.WebUI.Services.BasketServices;
using Microsoft.AspNetCore.Mvc;

namespace BerkayShop.WebUI.ViewComponents.OrderViewComponentPartial
{
    public class _OrderSummaryOrderComponentPartial : ViewComponent
    {
        private readonly IBasketService _basketService;

        public _OrderSummaryOrderComponentPartial(IBasketService basketService)
        {
            _basketService = basketService;
        }

        public async Task<IViewComponentResult> InvokeAsync(decimal LastPriceAfterDiscount)
        {
            var values = await _basketService.GetBasket();
            ViewBag.LastPriceAfterDiscount = LastPriceAfterDiscount;
            return View(values);
        }
    }
}
