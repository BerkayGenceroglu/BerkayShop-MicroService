using BerkayShop.DtoLayer.CatalogDtos.OfferDiscountDtos;
using BerkayShop.WebUI.Services.CatalogServices.OfferDiscountService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BerkayShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[Controller]/[Action]/{id?}")]
    public class OfferDiscountController : Controller
    {
        private readonly IOfferDiscountService _offerDiscountService;
        public OfferDiscountController(IHttpClientFactory httpClientFactory, IOfferDiscountService offerDiscountService)
        {
            _offerDiscountService = offerDiscountService;
        }

        public async Task<IActionResult> OfferDiscountList()
        {
            ViewBag.MainTitle = "Özel İndirim Teklif İşlemleri";
            ViewBag.Title1 = "Anasayfa";
            ViewBag.Title2 = "Özel İndirim Teklifler";
            ViewBag.Title3 = "Özel İndirim Teklif Listesi";
            
            var values = await _offerDiscountService.GetAllOfferDiscountAsync();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddOfferDiscount()
        {
            ViewBag.MainTitle = "Özel İndirim Teklif İşlemleri";
            ViewBag.Title1 = "Anasayfa";
            ViewBag.Title2 = "Özel İndirim Teklifler";
            ViewBag.Title3 = "Özel İndirim Teklif Ekle";

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddOfferDiscount(CreateOfferDiscountDto createOfferDiscountDto)
        {
            await _offerDiscountService.CreateOfferDiscountAsync(createOfferDiscountDto);
            return RedirectToAction("OfferDiscountList", "OfferDiscount", new { Area = "Admin" });
         
        }

        public async Task<IActionResult> RemoveOfferDiscount(string id)
        {
            await _offerDiscountService.DeleteOfferDiscountAsync(id);
            return RedirectToAction("OfferDiscountList", "OfferDiscount", new { Area = "Admin" });
        }

        [HttpGet]
        public async Task<IActionResult> UpdateOfferDiscount(string id)
        {
            ViewBag.MainTitle = "Özel İndirim Teklif İşlemleri";
            ViewBag.Title1 = "Anasayfa";
            ViewBag.Title2 = "Özel İndirim Teklifler";
            ViewBag.Title3 = "Özel İndirim Teklif Güncelle";

            var values = await _offerDiscountService.GetByIdOfferDiscountAsync(id);
            var UpdateOfferDiscountValue = new UpdateOfferDiscountDto
            {
                OfferDiscountId = values.OfferDiscountId,
                Title = values.Title,
                SubTitle = values.SubTitle,
                ImageUrl = values.ImageUrl,
                ButtonName = values.ButtonName
            };
            return View(UpdateOfferDiscountValue);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateOfferDiscount(UpdateOfferDiscountDto dto)
        {
            await _offerDiscountService.UpdateOfferDiscountAsync(dto);
            return RedirectToAction("OfferDiscountList", "OfferDiscount", new { Area = "Admin" });
          
        }
    }
}
