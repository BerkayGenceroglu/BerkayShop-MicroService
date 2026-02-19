using BerkayShop.DtoLayer.CatalogDtos.ProductDtos;
using BerkayShop.WebUI.Services.CatalogServices.ProductServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace BerkayShop.WebUI.ViewComponents.ProductDetailViewComponentPartial
{
    public class _ProductFeatureProductDetailComponentPartial : ViewComponent
    {
        private readonly IProductService _productService;

        public _ProductFeatureProductDetailComponentPartial(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string productId)
        {
            var value = await _productService.GetByIdProductAsync(productId);
            return View(value);
        }
    }
}
