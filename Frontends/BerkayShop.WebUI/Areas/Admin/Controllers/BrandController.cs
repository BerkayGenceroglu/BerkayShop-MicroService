using BerkayShop.DtoLayer.CatalogDtos.BrandDtos;
using BerkayShop.WebUI.Services.CatalogServices.BrandService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BerkayShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[Controller]/[Action]/{id?}")]
    public class BrandController : Controller
    {
        private readonly IBrandService _brandService;

        public BrandController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        public async Task<IActionResult> BrandList()
        {
            ViewBag.MainTitle = "Marka İşlemleri";
            ViewBag.Title1 = "Anasayfa";
            ViewBag.Title2 = "Markalar";
            ViewBag.Title3 = "Marka Listesi";

            var values = await _brandService.GetAllBrandAsync();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddBrand()
        {
            ViewBag.MainTitle = "Marka İşlemleri";
            ViewBag.Title1 = "Anasayfa";
            ViewBag.Title2 = "Markalar";
            ViewBag.Title3 = "Marka Ekle";

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddBrand(CreateBrandDto createBrandDto)
        {
            await _brandService.CreateBrandAsync(createBrandDto);
            return RedirectToAction("BrandList", "Brand", new { Area = "Admin" });
        }
        public async Task<IActionResult> RemoveBrand(string id)
        {
            await _brandService.DeleteBrandAsync(id);
            return RedirectToAction("BrandList", "Brand", new { Area = "Admin" });
        }

        [HttpGet]
        public async Task<IActionResult> UpdateBrand(string id)
        {
            ViewBag.MainTitle = "Marka İşlemleri";
            ViewBag.Title1 = "Anasayfa";
            ViewBag.Title2 = "Markalar";
            ViewBag.Title3 = "Marka Güncelle";

            var values =await _brandService.GetByIdBrandAsync(id);
            var UpdateBrandValue = new UpdateBrandDto
            {
                BrandId = values.BrandId,
                BrandName = values.BrandName,
                ImageUrl = values.ImageUrl
            };
            return View(UpdateBrandValue);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateBrand(UpdateBrandDto dto)
        {
            await _brandService.UpdateBrandAsync(dto);
            return RedirectToAction("BrandList", "Brand", new { Area = "Admin" });
        }
    }
}
