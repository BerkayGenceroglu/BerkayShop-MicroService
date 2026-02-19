using BerkayShop.WebUI.Services.Interfaces;
using BerkayShop.WebUI.Services.MessageServices;
using Microsoft.AspNetCore.Mvc;

namespace BerkayShop.WebUI.Areas.User.Controllers
{

    [Area("User")]
    public class MessageController : Controller
    {
        private readonly IMessageService _messageService;
        private readonly IUserService _userService;

        public MessageController(IMessageService messageService, IUserService userService)
        {
            _messageService = messageService;
            _userService = userService;
        }

        public async Task<IActionResult> Inbox()
        {
            var user = await _userService.GetUserInfo();
            var messages = await _messageService.GetAllInboxMessageAsync(user.Id);
            return View(messages);
        }
        public async Task<IActionResult> Sendbox()
        {
            var user = await _userService.GetUserInfo();
            var messages = await _messageService.GetAllSendboxMessageAsync(user.Id);
            return View(messages);
        }
    }
}
