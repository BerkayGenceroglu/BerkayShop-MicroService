using BerkayShop.DtoLayer.CatalogDtos.ProductDetailDtos;
using BerkayShop.WebUI.Services.CatalogServices.ProductDetailService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BerkayShop.WebUI.Areas.Admin.Controllers
{
    [Route("Admin/[Controller]/[Action]/{id?}")]
    [Area("Admin")]
    public class ProductDetailController : Controller
    {
        private readonly IProductDetailService _productDetailService;

        public ProductDetailController(IProductDetailService productDetailService)
        {
            _productDetailService = productDetailService;
        }

        [HttpGet]
        public async Task<IActionResult> UpdateProductDetail(string productId)
        {
            ViewBag.MainTitle = "Ürün Açıklama ve Bilgi İşlemleri";
            ViewBag.Title1 = "Anasayfa";
            ViewBag.Title2 = "Ürün Açıklama ve Bilgi Görseller";
            ViewBag.Title3 = "Ürün Açıklama ve Bilgi Güncelle";

            var values = await _productDetailService.GetByProductIdProductDetailAsync(productId);
            var UpdateProductDetailDto = new UpdateProductDetailDto
            {
                ProductDetailId = values.ProductDetailId,
                ProductDescription = values.ProductDescription,
                ProductInfo = values.ProductInfo,
                ProductId = values.ProductId
            };
            return View(UpdateProductDetailDto);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateProductDetail(UpdateProductDetailDto dto)
        {
            await _productDetailService.UpdateProductDetailAsync(dto);
            return RedirectToAction("ProductListWithCategory", "Product", new { Area = "Admin" });
        }
    }
}
