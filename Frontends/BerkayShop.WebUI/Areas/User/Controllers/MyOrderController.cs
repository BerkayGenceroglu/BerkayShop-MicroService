using BerkayShop.WebUI.Services.Interfaces;
using BerkayShop.WebUI.Services.OrderServices.OrderOrderingService;
using Microsoft.AspNetCore.Mvc;

namespace BerkayShop.WebUI.Areas.User.Controllers
{

    [Area("User")]
    public class MyOrderController : Controller
    {
        private readonly IOrderOrderingService _orderOrderingService;
        private readonly IUserService _userService;

        public MyOrderController(IOrderOrderingService orderOrderingService, IUserService userService)
        {
            _orderOrderingService = orderOrderingService;
            _userService = userService;
        }

        public async Task<IActionResult> Index()
        {
            var userInfo = await _userService.GetUserInfo();
            var Orders = await _orderOrderingService.GetOrderingByUserIdAsync(userInfo.Id);
            return View(Orders);
        }
    }
}
