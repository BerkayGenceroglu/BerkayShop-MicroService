using BerkayShop.WebUI.Services.CargoServices.CargoCustomerServices;
using BerkayShop.WebUI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BerkayShop.WebUI.Controllers
{

    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public async  Task<IActionResult> Index()
        {
            var values =await _userService.GetUserInfo();
            return View(values);
        }

    }
}
