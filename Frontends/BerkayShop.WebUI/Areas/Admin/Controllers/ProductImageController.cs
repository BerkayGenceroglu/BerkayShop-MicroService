using BerkayShop.DtoLayer.CatalogDtos.ProductImageDtos;
using BerkayShop.WebUI.Services.CatalogServices.ProductImageService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BerkayShop.WebUI.Areas.Admin.Controllers
{
    [Route("Admin/[Controller]/[Action]/{id?}")]
    [Area("Admin")]
    public class ProductImageController : Controller
    {
        private readonly IProductImageService _productImageService;

        public ProductImageController(IProductImageService productImageService)
        {
            _productImageService = productImageService;
        }

        [HttpGet]
        public async Task<IActionResult> UpdateProductImage(string productId)
        {
            ViewBag.MainTitle = "Ürün Görsel İşlemleri";
            ViewBag.Title1 = "Anasayfa";
            ViewBag.Title2 = "Ürün Görseller";
            ViewBag.Title3 = "Ürün Görsel Güncelle";

            var values = await _productImageService.GetByProductIdProductImageAsync(productId);

            var UpdateProductImage = new UpdateProductImageDto
            {
                ProductImageId = values.ProductImageId,
                Image1 = values.Image1,
                Image2 = values.Image2,
                Image3 = values.Image3,
                Image4 = values.Image4,
                ProductId = values.ProductId
            };
            return View(UpdateProductImage);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateProductImage(UpdateProductImageDto dto)
        {
            await _productImageService.UpdateProductImageAsync(dto);
            return RedirectToAction("ProductListWithCategory", "Product", new { Area = "Admin" });
            
        }
    }
}
