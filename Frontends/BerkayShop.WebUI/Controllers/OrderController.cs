using BerkayShop.DtoLayer.OrderDtos.OrderAddressDto;
using BerkayShop.WebUI.Services.Interfaces;
using BerkayShop.WebUI.Services.OrderServices.OrderAddressService;
using Microsoft.AspNetCore.Mvc;

namespace BerkayShop.WebUI.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderAddressService _orderAddressService;
        private readonly IUserService _userService;
        public OrderController(IOrderAddressService orderAddressService, IUserService userService)
        {
            _orderAddressService = orderAddressService;
            _userService = userService;
        }

        public IActionResult Index(decimal LastPriceAfterDiscount)
        {
            ViewBag.Directory1 = "BerkayShop";
            ViewBag.Directory2 = "Siparişler";
            ViewBag.Directory3 = "Sipariş Bilgileri";
            ViewBag.LastPriceAfterDiscount = LastPriceAfterDiscount;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrderAddress(CreateOrderAddressDto dto)
        {
            var user = await _userService.GetUserInfo();
            dto.UserId = user.Id;
            await _orderAddressService.CreateOrderAddressAsync(dto);
            return RedirectToAction("Index","Order");
        }
    }
}
