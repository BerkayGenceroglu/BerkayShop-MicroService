using BerkayShop.DtoLayer.CargoDtos.CargoCompanyDtos;
using BerkayShop.WebUI.Services.CargoServices.CargoCompanyServices;
using Microsoft.AspNetCore.Mvc;

namespace BerkayShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[Controller]/[Action]/{id?}")]
    
    public class CargoController : Controller
    {
        private readonly ICargoCompanyService _cargoCompanyService;

        public CargoController(ICargoCompanyService cargoCompanyService)
        {
            _cargoCompanyService = cargoCompanyService;
        }

        public async Task<IActionResult> CargoCompanyList()
        {
            var values = await _cargoCompanyService.GetAllCargoCompanyAsync();
            return View(values);
        }

        public async Task<IActionResult> RemoveCargoCompany(int id)
        {
            await _cargoCompanyService.DeleteCargoCompanyAsync(id);
            return RedirectToAction("CargoCompanyList", "Cargo");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateCargoCompany(int id)
        {
            var value = await _cargoCompanyService.GetByIdCargoCompanyAsync(id);
            var updateDto = new UpdateCargoCompanyDto
            {
                CargoCompanyId = value.CargoCompanyId,
                CargoCompanyName = value.CargoCompanyName
            };
            return View(updateDto);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateCargoCompany(UpdateCargoCompanyDto dto)
        {
            await _cargoCompanyService.UpdateCargoCompanyAsync(dto);
            return RedirectToAction("CargoCompanyList", "Cargo");
        }
        [HttpGet]
        public IActionResult AddCargoCompany()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddCargoCompany(CreateCargoCompanyDto dto)
        {
            await _cargoCompanyService.CreateCargoCompanyAsync(dto);
            return RedirectToAction("CargoCompanyList", "Cargo");
        }
    }
}
