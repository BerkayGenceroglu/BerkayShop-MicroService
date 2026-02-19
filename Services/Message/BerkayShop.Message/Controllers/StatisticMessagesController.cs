using BerkayShop.Message.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BerkayShop.Message.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticMessagesController : ControllerBase
    {
        private readonly IUserMessageService _userMessageService;

        public StatisticMessagesController(IUserMessageService userMessageService)
        {
            _userMessageService = userMessageService;
        }

        [HttpGet]
        public async Task<IActionResult> GetTotalMessage()
        {
            var TotalMessage = await _userMessageService.GetTotalMessageCount();
            return Ok(TotalMessage);
        }
    }
}
