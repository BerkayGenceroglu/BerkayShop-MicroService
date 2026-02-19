using BerkayShop.WebUI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BerkayShop.WebUI.Areas.User.Controllers
{

    [Area("User")]
    public class ProfileController : Controller
    {
        private readonly IUserService _userService;

        public ProfileController(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _userService.GetUserInfo();
            return View(values);
        }
    }
}
