using BerkayShop.DtoLayer.BasketDtos;
using BerkayShop.WebUI.Services.BasketServices;
using BerkayShop.WebUI.Services.CatalogServices.ProductServices;
using Microsoft.AspNetCore.Mvc;
using NuGet.ContentModel;

namespace BerkayShop.WebUI.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IProductService _productService;
        private readonly IBasketService _basketService;

        public ShoppingCartController(IProductService productService, IBasketService basketService)
        {
            _productService = productService;
            _basketService = basketService;
        }

        public async Task<IActionResult> BasketPage(string CouponCode,int rate)
        {
            ViewBag.Directory1 = "BerkayShop";
            ViewBag.Directory2 = "Sepetim";
            ViewBag.Directory3 = "Ürünler";
            ViewBag.CouponCode = CouponCode;
            ViewBag.Rate = rate;
            var Ratee = ViewBag.Rate;
            var values = await _basketService.GetBasket();
            ViewBag.TotalPrice = values.TotalPrice;
            var SumPrice = ViewBag.TotalPrice;
            var Kdv = 10;
            ViewBag.Kdv = 10;
            ViewBag.TotalPriceWithKdv = SumPrice + (SumPrice * Kdv / 100);
            var TotalPrice = ViewBag.TotalPriceWithKdv;
            ViewBag.LastPriceAfterDiscount = TotalPrice - (TotalPrice * Ratee/100);
            return View();
        }

        public async Task<IActionResult> AddBasketItem(string productId)
        {
            var values = await _productService.GetByIdProductAsync(productId);
            if (values != null)
            {
                await _basketService.AddBasketItem(new BasketItemDto
                {
                    ProductId = values.ProductId,
                    ProductName = values.ProductName,
                    Price = values.ProductPrice,
                    ProductImageUrl = values.ProductImageUrl,
                    Quantity = 1,
                });
                return RedirectToAction("BasketPage","ShoppingCart");
            }
            return RedirectToAction("DefaultPage", "Default");
        }

        public async Task<IActionResult> RemoveBasketItem(string productId)
        {
            await _basketService.RemoveBasketItem(productId);
            return RedirectToAction("BasketPage", "ShoppingCart");
        }
    }
}
