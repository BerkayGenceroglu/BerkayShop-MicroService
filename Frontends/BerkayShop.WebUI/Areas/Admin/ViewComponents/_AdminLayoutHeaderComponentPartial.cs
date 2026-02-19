using BerkayShop.WebUI.Services.Interfaces;
using BerkayShop.WebUI.Services.MessageServices;
using Microsoft.AspNetCore.Mvc;

namespace BerkayShop.WebUI.Areas.Admin.ViewComponents
{
    public class _AdminLayoutHeaderComponentPartial : ViewComponent
    {
        private readonly IMessageService _messageService;
        private readonly IUserService _userService;

        public _AdminLayoutHeaderComponentPartial(IMessageService messageService, IUserService userService)
        {
            _messageService = messageService;
            _userService = userService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userService.GetUserInfo();
            var messageCount = await _messageService.GetMessageCountByUserId(user.Id);
            ViewBag.messageCount = messageCount;

            ViewBag.UserId = user.Id;
            return View();
        }
    }
}
