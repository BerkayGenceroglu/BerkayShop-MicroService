using BerkayShop.DtoLayer.CatalogDtos.ProductImageDtos;
using BerkayShop.WebUI.Services.CatalogServices.ProductImageService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BerkayShop.WebUI.ViewComponents.ProductDetailViewComponentPartial
{
    public class _ProductImageSliderProductDetailComponentPartial : ViewComponent
    {
        private readonly IProductImageService _productImageService;

        public _ProductImageSliderProductDetailComponentPartial(IProductImageService productImageService)
        {
            _productImageService = productImageService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string productId)
        {
            var value = await _productImageService.GetByProductIdProductImageAsync(productId);
            return View(value);
        }
    }
}
