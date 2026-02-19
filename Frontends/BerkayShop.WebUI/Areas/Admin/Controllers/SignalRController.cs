using BerkayShop.WebUI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BerkayShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[Controller]/[Action]/{id?}")]
    public class SignalRController : Controller
    {
        private readonly IUserService _userService;

        public SignalRController(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IActionResult> Index()
        {
            var user =await _userService.GetUserInfo();
            ViewBag.UserId = user.Id;
            return View();
        }
    }
}
