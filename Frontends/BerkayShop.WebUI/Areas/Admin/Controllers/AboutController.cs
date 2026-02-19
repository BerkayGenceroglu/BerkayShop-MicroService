using BerkayShop.DtoLayer.CatalogDtos.AboutDtos;
using BerkayShop.WebUI.Services.CatalogServices.AboutService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BerkayShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[Controller]/[Action]/{id?}")]
    public class AboutController : Controller
    { 
        private readonly IAboutService _aboutService;

        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        public async Task<IActionResult> AboutList()
        {
            ViewBag.MainTitle = "Hakkımda İşlemleri";
            ViewBag.Title1 = "Anasayfa";
            ViewBag.Title2 = "Hakkımda";
            ViewBag.Title3 = "Hakkımda Listesi";

            var values = await _aboutService.GetAllAboutAsync();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddAbout()
        {
            ViewBag.MainTitle = "Hakkımda İşlemleri";
            ViewBag.Title1 = "Anasayfa";
            ViewBag.Title2 = "Hakkımda";
            ViewBag.Title3 = "Hakkımda Ekle";

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddAbout(CreateAboutDto createAboutDto)
        {
            await _aboutService.CreateAboutAsync(createAboutDto);
            return RedirectToAction("AboutList", "About", new { Area = "Admin" });
        }
        public async Task<IActionResult> RemoveAbout(string id)
        {
            await _aboutService.DeleteAboutAsync(id);
            return RedirectToAction("AboutList", "About", new { Area = "Admin" });
        }

        [HttpGet]
        public async Task<IActionResult> UpdateAbout(string id)
        {
            ViewBag.MainTitle = "Hakkımda İşlemleri";
            ViewBag.Title1 = "Anasayfa";
            ViewBag.Title2 = "Hakkımda";
            ViewBag.Title3 = "Hakkımda Güncelle";

            var value =await _aboutService.GetByIdAboutAsync(id);
            var UpdateAboutValue = new UpdateAboutDto
            {
                AboutId = value.AboutId,
                Description = value.Description,
                Address = value.Address,
                Email = value.Email,
                Phone = value.Phone
            };
            return View(UpdateAboutValue);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateAbout(UpdateAboutDto dto)
        {
             await _aboutService.UpdateAboutAsync(dto);
            return RedirectToAction("AboutList", "About", new { Area = "Admin" });
        }
    }
}
