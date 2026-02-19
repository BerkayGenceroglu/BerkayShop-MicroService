using BerkayShop.Catalog.Services.StatisticService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BerkayShop.Catalog.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly IStatisticService _statisticService;

        public StatisticsController(IStatisticService statisticService)
        {
            _statisticService = statisticService;
        }
        [HttpGet("GetBrandCount")]
        public IActionResult GetBrandCount()
        {
            var value = _statisticService.GetBrandCount();
            return Ok(value);
        }

        [HttpGet("GetProductCount")]
        public IActionResult GetProductCount()
        {
            return Ok(_statisticService.GetProductCount());
        }

        [HttpGet("GetCategoryCount")]
        public IActionResult GetCategoryCount()
        {
            return Ok(_statisticService.GetCategoryCount());
        }


        [HttpGet("GetProductAvgPrice")]
        public async Task<IActionResult> GetProductAvgPrice()
        {
            return Ok(await _statisticService.GetProductAvgPrice());
        }

        [HttpGet("GetMaxPriceProductName")]
        public async Task<IActionResult> GetMaxPriceProductName()
        {
            return Ok(await _statisticService.GetMaxPriceProductName());
        }

        [HttpGet("GetMinPriceProductName")]
        public async Task<IActionResult> GetMinPriceProductName()
        {
            return Ok(await _statisticService.GetMinPriceProductName());
        }

        [HttpGet("GetTotalDiscountCount")]
        public IActionResult GetTotalDiscountCount()
        {
            return Ok(_statisticService.GetTotalDiscountCount());
        }
    }
}
