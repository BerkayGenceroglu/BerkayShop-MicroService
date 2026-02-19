using BerkayShop.WebUI.Services.CargoServices.CargoCustomerServices;
using BerkayShop.WebUI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BerkayShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[Controller]/[Action]/{id?}")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly ICargoCustomerService _cargoCustomerService;

        public UserController(IUserService userService, ICargoCustomerService cargoCustomerService)
        {
            _userService = userService;
            _cargoCustomerService = cargoCustomerService;
        }

        public async Task<IActionResult> UserList()
        {
            var values = await _userService.GetAlluser();
            return View(values);
        }

        public async Task<IActionResult> GetUserAddress(string userId)
        {
            var values = await _cargoCustomerService.GetCargoCustomerByUserIdAsync(userId);
            return View(values);
        }
    }
}
