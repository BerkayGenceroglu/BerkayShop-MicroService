using BerkayShop.DtoLayer.CatalogDtos.ProductDetailDtos;
using BerkayShop.WebUI.Services.CatalogServices.ProductDetailService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BerkayShop.WebUI.ViewComponents.ProductDetailViewComponentPartial
{
    public class _DescriptionProductDetailComponentPartial : ViewComponent
    {
        private readonly IProductDetailService _productDetailService;

        public _DescriptionProductDetailComponentPartial(IProductDetailService productDetailService)
        {
            _productDetailService = productDetailService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string productId)
        {
             var value = await _productDetailService.GetByProductIdProductDetailAsync(productId);
            return View(value);
        }
    }
}
