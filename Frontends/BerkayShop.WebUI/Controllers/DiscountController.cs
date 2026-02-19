using BerkayShop.WebUI.Services.BasketServices;
using BerkayShop.WebUI.Services.DiscountServices;
using Microsoft.AspNetCore.Mvc;

namespace BerkayShop.WebUI.Controllers
{
    public class DiscountController : Controller
    {
        private readonly IDiscountService _discountService;
        private readonly IBasketService _basketService;
        public DiscountController(IDiscountService discountService, IBasketService basketService)
        {
            _discountService = discountService;
            _basketService = basketService;
        }


        [HttpPost]
        public async Task<IActionResult> ConfirmDiscountCoupon(string code)
        {
            var coupon = await _discountService.GetDiscountCode(code);
            var basket = await _basketService.GetBasket();

            var kdv = 10;
            var totalWithKdv = basket.TotalPrice + (basket.TotalPrice * kdv / 100);
            var discountedTotal = totalWithKdv - (totalWithKdv * coupon.Rate / 100);
            var Rate = coupon.Rate;
            return RedirectToAction("BasketPage", "ShoppingCart", new {CouponCode =code, rate = Rate});
        }
    }
}
