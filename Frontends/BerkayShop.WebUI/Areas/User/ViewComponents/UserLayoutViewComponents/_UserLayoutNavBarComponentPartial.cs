using BerkayShop.WebUI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BerkayShop.WebUI.Areas.User.ViewComponents.UserLayoutViewComponents
{
    public class _UserLayoutNavBarComponentPartial : ViewComponent
    {
        private readonly IUserService _userService;

        public _UserLayoutNavBarComponentPartial(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userService.GetUserInfo();
            ViewBag.Name = user.Name + user.Surname;
            return View();
        }
    }
}
