using BerkayShop.DtoLayer.CatalogDtos.FeatureDtos;
using BerkayShop.WebUI.Services.CatalogServices.FeatureServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BerkayShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[Controller]/[Action]/{id?}")]
    public class FeatureController : Controller
    {
        private readonly IFeatureService _featureService;

        public FeatureController(IFeatureService featureService)
        {
            _featureService = featureService;
        }

        public async Task<IActionResult> FeatureList()
        {
            ViewBag.MainTitle = "Öne Çıkan Özellikler İşlemleri";
            ViewBag.Title1 = "Anasayfa";
            ViewBag.Title2 = "Öne Çıkan Özellikler";
            ViewBag.Title3 = "Öne Çıkan Özellikler Listesi";

            var values = await _featureService.GetAllFeatureAsync();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddFeature()
        {
            ViewBag.MainTitle = "Öne Çıkan Özellikler İşlemleri";
            ViewBag.Title1 = "Anasayfa";
            ViewBag.Title2 = "Öne Çıkan Özellikler";
            ViewBag.Title3 = "Öne Çıkan Özellikler Ekle";

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddFeature(CreateFeatureDto createFeatureDto)
        {
            await _featureService.CreateFeatureAsync(createFeatureDto);
            return RedirectToAction("FeatureList", "Feature", new { Area = "Admin" });

        }
        public async Task<IActionResult> RemoveFeature(string id)
        {
            await _featureService.DeleteFeatureAsync(id);
            return RedirectToAction("FeatureList", "Feature", new { Area = "Admin" });

        }

        [HttpGet]
        public async Task<IActionResult> UpdateFeature(string id)
        {
            ViewBag.MainTitle = "Öne Çıkan Özellikler İşlemleri";
            ViewBag.Title1 = "Anasayfa";
            ViewBag.Title2 = "Öne Çıkan Özellikler";
            ViewBag.Title3 = "Öne Çıkan Özellikler Güncelle";

            var value = await _featureService.GetByIdFeatureAsync(id);
            var UpdateFeatureValue = new UpdateFeatureDto
            {
                FeatureId = value.FeatureId,
                Title = value.Title,
                Icon = value.Icon
            };
            return View(UpdateFeatureValue);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateFeature(UpdateFeatureDto dto)
        {
            await _featureService.UpdateFeatureAsync(dto);
            return RedirectToAction("FeatureList", "Feature", new { Area = "Admin" });
            
        }
    }
}
