using BerkayShop.WebUI.Services.OrderServices.OrderAllOrderingService;
using Microsoft.AspNetCore.Mvc;

namespace BerkayShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[Controller]/[Action]/{id?}")]
    public class OrderController : Controller
    {
        private readonly IOrderingService _orderingService;

        public OrderController(IOrderingService orderingService)
        {
            _orderingService = orderingService;
        }

        public async Task<IActionResult> OrderList()
        {
            ViewBag.MainTitle = "Sipariş İşlemleri";
            ViewBag.Title1 = "Anasayfa";
            ViewBag.Title2 = "Siparişler";
            ViewBag.Title3 = "Sipariş Listesi";
            var values = await _orderingService.GetAllOrder();
            return View(values);
        }
    }
}
