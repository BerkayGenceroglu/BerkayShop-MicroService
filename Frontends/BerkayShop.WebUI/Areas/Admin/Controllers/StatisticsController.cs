using BerkayShop.WebUI.Services.StatisticServices.CargoStatisticService;
using BerkayShop.WebUI.Services.StatisticServices.CatalogStatisticService;
using BerkayShop.WebUI.Services.StatisticServices.CommentStatisticService;
using BerkayShop.WebUI.Services.StatisticServices.DiscountCouponService;
using BerkayShop.WebUI.Services.StatisticServices.MessageStatisticService;
using BerkayShop.WebUI.Services.StatisticServices.OrderStatisticService;
using BerkayShop.WebUI.Services.StatisticServices.UserStatisticService;
using Microsoft.AspNetCore.Mvc;

namespace BerkayShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[Controller]/[Action]/{id?}")]
    public class StatisticsController : Controller
    {
        private readonly ICatalogStatisticService _catalogStatisticService;
        private readonly ICommentStatisticService _commentStatisticService;
        private readonly IMessageStatisticService _messageStatisticService;
        private readonly IUserStatisticService _userStatisticService;
        private readonly IOrderStatisticService _orderStatisticService;
        private readonly ICargoStatisticService _cargoStatisticService;
        private readonly ICouponStatisticService _couponStatisticService;
        public StatisticsController(ICatalogStatisticService catalogStatisticService, ICommentStatisticService commentStatisticService, IMessageStatisticService messageStatisticService, IUserStatisticService userStatisticService, ICouponStatisticService couponStatisticService, IOrderStatisticService orderStatisticService, ICargoStatisticService cargoStatisticService)
        {
            _catalogStatisticService = catalogStatisticService;
            _commentStatisticService = commentStatisticService;
            _messageStatisticService = messageStatisticService;
            _userStatisticService = userStatisticService;
            _couponStatisticService = couponStatisticService;
            _orderStatisticService = orderStatisticService;
            _cargoStatisticService = cargoStatisticService;
        }

        public async Task<IActionResult> StatisticsPage()
        {
            var BrandCount = await _catalogStatisticService.GetBrandCount();
            ViewBag.BrandCount = BrandCount;

            var CategoryCount = await _catalogStatisticService.GetCategoryCount();
            ViewBag.CategoryCount = CategoryCount;

            var ProductCount = await _catalogStatisticService.GetProductCount();
            ViewBag.ProductCount = ProductCount;

            var ProductAvgPrice = await _catalogStatisticService.GetProductAvgPrice();
            ViewBag.ProductAvgPrice = ProductAvgPrice;

            var MaxPriceProductName = await _catalogStatisticService.GetMaxPriceProductName();
            ViewBag.MaxPriceProductName = MaxPriceProductName;

            var MinPriceProductName = await _catalogStatisticService.GetMinPriceProductName();
            ViewBag.MinPriceProductName = MinPriceProductName;

            var ActiveCommentCount = await _commentStatisticService.GetActiveCommentCountAsync();
            ViewBag.ActiveCommentCount = ActiveCommentCount;

            var PassiveCommentCount = await _commentStatisticService.GetPassiveCommentCountAsync();
            ViewBag.PassiveCommentCount = PassiveCommentCount;

            var TotalCommentCount = await _commentStatisticService.GetTotalCommentCountAsync();
            ViewBag.TotalCommentCount = TotalCommentCount;

            var TotalMessageCount = await _messageStatisticService.GetTotalMessageCount();
            ViewBag.TotalMessageCount = TotalMessageCount;

            var TotalUserCount = await _userStatisticService.GetUserCount();
            ViewBag.TotalUserCount = TotalUserCount;

            var TotalCouponCount = await _couponStatisticService.GetDiscountCouponCountAsync();
            ViewBag.TotalCouponCount = TotalCouponCount;

            var TotalOrderPriceCount = await _orderStatisticService.GetOrderingTotalPrice();
            ViewBag.TotalOrderPriceCount = TotalOrderPriceCount;

            var TotalCargoCompanyCount = await _cargoStatisticService.GetTotalCargoCompanyCount();
            ViewBag.TotalCargoCompanyCount = TotalCargoCompanyCount;

            var LastOrderDate = await _orderStatisticService.GetLastOrderDate();
            ViewBag.LastOrderDate = LastOrderDate;

            var TotalDiscountCount = await _catalogStatisticService.GetTotalDiscountCount();
            ViewBag.TotalDiscountCount = TotalDiscountCount;
            return View();
        }
    }
}
