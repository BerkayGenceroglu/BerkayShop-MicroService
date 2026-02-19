using BerkayShop.Basket.Dtos;
using BerkayShop.Basket.LoginServices;
using BerkayShop.Basket.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BerkayShop.Basket.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BasketsController : ControllerBase
    {
        private readonly IBasketService _basketService;
        private readonly ILoginService _loginService;

        public BasketsController(IBasketService basketService, ILoginService loginService)
        {
            _basketService = basketService;
            _loginService = loginService;
        }
        [HttpGet]
        public async Task<IActionResult> GetMyBasketDetail()
        {
            var claims = User.Claims;
            var values =await _basketService.GetBasket(_loginService.GetUserId);
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> AddMyBasket(BasketTotalDto dto)
        {
            dto.UserId = _loginService.GetUserId;
            await _basketService.SaveBasket(dto);
            return Ok("Sepetteki Değişiklikler Başarıyla Kaydedildi");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteBasket()
        {
            await _basketService.DeleteBasket(_loginService.GetUserId);
            return Ok("Sepetiniz Başarıyla Silinmiştir");
        }
    }
}
