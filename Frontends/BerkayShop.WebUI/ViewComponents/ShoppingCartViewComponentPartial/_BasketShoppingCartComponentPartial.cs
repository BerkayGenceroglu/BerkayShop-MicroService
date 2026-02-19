using BerkayShop.WebUI.Services.BasketServices;
using Microsoft.AspNetCore.Mvc;

namespace BerkayShop.WebUI.ViewComponents.ShoppingCartViewComponentPartial
{
    public class _BasketShoppingCartComponentPartial : ViewComponent
    {
        private readonly IBasketService _basketService;

        public _BasketShoppingCartComponentPartial(IBasketService basketService)
        {
            _basketService = basketService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _basketService.GetBasket();
            return View(values);
        }
    }
}
