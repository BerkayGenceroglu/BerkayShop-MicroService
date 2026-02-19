using BerkayShop.DtoLayer.CatalogDtos.ProductDtos;
using BerkayShop.WebUI.Services.CatalogServices.ProductServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BerkayShop.WebUI.ViewComponents.ProductListViewComponentPartial
{
    public class _AllProductsProductListComponentPartial: ViewComponent
    {
        private readonly IProductService _productService;

        public _AllProductsProductListComponentPartial(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string categoryId)
        {
            var values = await _productService.GetProductWithCategoryByCategoryIdAsync(categoryId);
            return View(values);
        }
    }
}
