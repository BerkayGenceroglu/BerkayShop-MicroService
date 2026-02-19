using BerkayShop.DtoLayer.CatalogDtos.ProductDtos;
using BerkayShop.WebUI.Services.CatalogServices.ProductServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BerkayShop.WebUI.ViewComponents.DefaultViewComponetPartial
{
    public class _FeaturedProductsDefaultComponentPartial : ViewComponent
    {
        private readonly IProductService _productService;

        public _FeaturedProductsDefaultComponentPartial(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _productService.GetAllProductAsync();
            return View(values.Take(8).ToList());
        }
    }
}
