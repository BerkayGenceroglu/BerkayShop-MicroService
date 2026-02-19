using BerkayShop.DtoLayer.CatalogDtos.FeatureSlideDtos;
using BerkayShop.WebUI.Services.CatalogServices.FeatureSliderService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BerkayShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[Controller]/[Action]/{id?}")]
    public class FeatureSliderController : Controller
    {
        private readonly IFeatureSliderService _featureSliderService;

        public FeatureSliderController(IFeatureSliderService featureSliderService)
        {
            _featureSliderService = featureSliderService;
        }

        public async Task<IActionResult> FeatureSliderList()
        {
            ViewBag.MainTitle = "Slider İşlemleri";
            ViewBag.Title1 = "Anasayfa";
            ViewBag.Title2 = "Öne Çıkan Sliderlar";
            ViewBag.Title3 = "Öne Çıkan Slider Listesi";

            var values = await _featureSliderService.GetAllFeatureSliderAsync();
            return View(values);

        }
        [HttpGet]
        public IActionResult AddFeatureSlider()
        {
            ViewBag.MainTitle = "Slider İşlemleri";
            ViewBag.Title1 = "Anasayfa";
            ViewBag.Title2 = "Öne Çıkan Sliderlar";
            ViewBag.Title3 = "Öne Çıkan Slider Ekle";

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddFeatureSlider(CreateFeatureSliderDto createFeatureSliderDto)
        {
            await _featureSliderService.CreateFeatureSliderAsync(createFeatureSliderDto);
            return RedirectToAction("FeatureSliderList", "FeatureSlider", new { Area = "Admin" });

        }
        public async Task<IActionResult> RemoveFeatureSlider(string id)
        {
            await _featureSliderService.DeleteFeatureSliderAsync(id);
            return RedirectToAction("FeatureSliderList", "FeatureSlider", new { Area = "Admin" });

        }

        [HttpGet]
        public async Task<IActionResult> UpdateFeatureSlider(string id)
        {
            ViewBag.MainTitle = "Slider İşlemleri";
            ViewBag.Title1 = "Anasayfa";
            ViewBag.Title2 = "Öne Çıkan Sliderlar";
            ViewBag.Title3 = "Öne Çıkan Slider Güncelle";
            
            var value =await _featureSliderService.GetByIdFeatureSliderAsync(id);
            var UpdatedValue = new UpdateFeatureSliderDto
            {
                Description = value.Description,
                FeatureSliderId = value.FeatureSliderId,
                ImageUrl = value.ImageUrl,
                Status = value.Status,
                Title = value.Title
            };
            return View(UpdatedValue);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateFeatureSlider(UpdateFeatureSliderDto dto)
        {
            await _featureSliderService.UpdateFeatureSliderAsync(dto);
            return RedirectToAction("FeatureSliderList", "FeatureSlider", new { Area = "Admin" });
          
        }
        public async Task<IActionResult> FeatureSliderStatusChangeToTrue(string id)
        {
            await _featureSliderService.FeatureSliderChangeStatusToTrue(id);
            return RedirectToAction("FeatureSliderList", "FeatureSlider", new { Area = "Admin" });
            
        }

        public async Task<IActionResult> FeatureSliderStatusChangeToFalse(string id)
        {
            await _featureSliderService.FeatureSliderChangeStatusToFalse(id);
            return RedirectToAction("FeatureSliderList", "FeatureSlider", new { Area = "Admin" });
        }
    }
}
