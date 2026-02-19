using BerkayShop.Discount.Dtos;
using BerkayShop.Discount.Entities;
using BerkayShop.Discount.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BerkayShop.Discount.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountService _discountService;

        public DiscountController(IDiscountService discountService)
        {
            _discountService = discountService;
        }
        [HttpGet]
        public async Task<IActionResult> GetCouponDiscount()
        {
           var values = await _discountService.GetAllDiscountAsync();
            return Ok (values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdDiscountCoupon(int id)
        { 
            var values = await _discountService.GetByIdDiscountAsync(id);
            return Ok(values);
        }

        [HttpGet("GetCodeDetailByCode/{code}")]
        public async Task<IActionResult> GetCodeDetailByCode(string code)
        {
            var values = await _discountService.GetCodeDetailByCodeAsync(code);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDiscountCoupon(CreateDiscountDto dto)
        {
            await _discountService.CreateDiscountAsync(dto);
            return Ok("Ekleme İşlemi Başarıyla Gerçekleşti");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDiscountCoupon(int id) 
        {
            await _discountService.DeleteDiscountAsync(id);
            return Ok("Silme İşlemi Başarıyla Gerçekleşti");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateDiscountCoupon(UpdateDiscountDto dto)
        {
            await _discountService.UpdateDiscountAsync(dto);
            return Ok("Güncelleme İşlemi Başarıyla Gerçekleşti");
        }
        [HttpGet("GetDiscountCouponCount")]
        public async Task<IActionResult> GetDiscountCouponCount()
        {
            var Count =await _discountService.GetDiscountCouponCountAsync();
            return Ok(Count);
        }
    }
}
