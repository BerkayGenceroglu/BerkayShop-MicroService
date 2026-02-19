using BerkayShop.DtoLayer.CatalogDtos.SpecialOfferDtos;
using BerkayShop.WebUI.Services.CatalogServices.SpecialOfferService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Net.Http;

namespace BerkayShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[Controller]/[Action]/{id?}")]
    public class SpecialOfferController : Controller
    {
        private readonly ISpecialOfferService _specialOfferService;

        public SpecialOfferController(ISpecialOfferService specialOfferService)
        {
            _specialOfferService = specialOfferService;
        }

        public async Task<IActionResult> SpecialOfferList()
        {
            ViewBag.MainTitle = "Özel İndirim İşlemleri";
            ViewBag.Title1 = "Anasayfa";
            ViewBag.Title2 = "Özel İndirimler";
            ViewBag.Title3 = "Özel İndirimler Listesi";

            var values = await _specialOfferService.GetAllSpecialOfferAsync();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddSpecialOffer()
        {
            ViewBag.MainTitle = "Özel İndirim İşlemleri";
            ViewBag.Title1 = "Anasayfa";
            ViewBag.Title2 = "Özel İndirimler";
            ViewBag.Title3 = "Özel İndirimler Listesi";

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddSpecialOffer(CreateSpecialOfferDto createSpecialOfferDto)
        {
            await _specialOfferService.CreateSpecialOfferAsync(createSpecialOfferDto);
            return RedirectToAction("SpecialOfferList", "SpecialOffer", new { Area = "Admin" });

        }
        public async Task<IActionResult> RemoveSpecialOffer(string id)
        {
            await _specialOfferService.DeleteSpecialOfferAsync(id);
            return RedirectToAction("SpecialOfferList", "SpecialOffer", new { Area = "Admin" });
        }

        [HttpGet]
        public async Task<IActionResult> UpdateSpecialOffer(string id)
        {
            ViewBag.MainTitle = "Özel İndirim İşlemleri";
            ViewBag.Title1 = "Anasayfa";
            ViewBag.Title2 = "Özel İndirimler";
            ViewBag.Title3 = "Özel İndirimler Listesi";

            var values = await _specialOfferService.GetByIdSpecialOfferAsync(id);
            var UpdateSpecialOffer = new UpdateSpecialOfferDto
            {
                SpecialOfferId = values.SpecialOfferId,
                Title = values.Title,
                SubTitle = values.SubTitle,
                ImageUrl = values.ImageUrl
            };
            return View(UpdateSpecialOffer);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateSpecialOffer(UpdateSpecialOfferDto dto)
        {
            await _specialOfferService.UpdateSpecialOfferAsync(dto);
            return RedirectToAction("SpecialOfferList", "SpecialOffer", new { Area = "Admin" });
            
        }
    }
}
