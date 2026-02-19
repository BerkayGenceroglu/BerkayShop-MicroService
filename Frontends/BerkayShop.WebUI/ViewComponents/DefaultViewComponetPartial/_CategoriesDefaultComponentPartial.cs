using BerkayShop.DtoLayer.CatalogDtos.CategoryDtos;
using BerkayShop.WebUI.Models;
using BerkayShop.WebUI.Services.CatalogServices.CategoryServices;
using BerkayShop.WebUI.Services.CatalogServices.ProductServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BerkayShop.WebUI.ViewComponents.DefaultViewComponetPartial
{
    public class _CategoriesDefaultComponentPartial : ViewComponent
    {
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;
        public _CategoriesDefaultComponentPartial(ICategoryService categoryService, IProductService productService)
        {
            _categoryService = categoryService;
            _productService = productService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _categoryService.GetAllCategoryAsync();
            var productValues = await _productService.GetAllProductAsync();
            var CategoryWithProductsViewModel = new CategoryWithProductsViewModel
            {
                Categories = values,
                Products = productValues
            };
            return View(CategoryWithProductsViewModel);
        }
    }
}
