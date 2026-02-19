using BerkayShop.DtoLayer.CatalogDtos.CategoryDtos;
using BerkayShop.DtoLayer.CatalogDtos.ProductDtos;
using BerkayShop.WebUI.Services.CatalogServices.CategoryServices;
using BerkayShop.WebUI.Services.CatalogServices.ProductServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace BerkayShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[Controller]/[Action]/{id?}")]
    public class ProductController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public ProductController(IHttpClientFactory httpClientFactory, IProductService productService, ICategoryService categoryService)
        {
            _httpClientFactory = httpClientFactory;
            _productService = productService;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> ProductList()
        {
            ViewBag.MainTitle = "Ürün İşlemleri";
            ViewBag.Title1 = "Anasayfa";
            ViewBag.Title2 = "Ürünler";
            ViewBag.Title3 = "Ürün Listesi";

            var values = await _productService.GetAllProductAsync();
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> AddProduct()
        {
            ViewBag.MainTitle = "Ürün İşlemleri";
            ViewBag.Title1 = "Anasayfa";
            ViewBag.Title2 = "Ürünler";
            ViewBag.Title3 = "Ürün Ekle";
            
            var categories = await _categoryService.GetAllCategoryAsync();
            ViewBag.Values = new SelectList(categories, "CategoryId", "CategoryName");

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddProduct(CreateProductDto dto)
        {
            await _productService.CreateProductAsync(dto);
            return RedirectToAction("ProductListWithCategory", "Product",new {Area= "Admin"});
         
        }
        
        public async Task<IActionResult> RemoveProduct(string id)
        {
            await _productService.DeleteProductAsync(id);
            return RedirectToAction("ProductListWithCategory", "Product", new { Area = "Admin" });
        }


        [HttpGet]
        public async Task<IActionResult> UpdateProduct(string id)
        {
            ViewBag.MainTitle = "Ürün İşlemleri";
            ViewBag.Title1 = "Anasayfa";
            ViewBag.Title2 = "Ürünler";
            ViewBag.Title3 = "Ürün Güncelle";
       
            var categories =  await _categoryService.GetAllCategoryAsync();
            var productValue =  await _productService.GetByIdProductAsync(id);
            var UpdatedValue = new UpdateProductDto
            {
                ProductId = productValue.ProductId,
                ProductName = productValue.ProductName,
                ProductPrice = productValue.ProductPrice,
                ProductImageUrl = productValue.ProductImageUrl,
                ProductDescription = productValue.ProductDescription,
                CategoryId = productValue.CategoryId
            };
            ViewBag.Values = new SelectList(
                categories,
                "CategoryId",
                "CategoryName",
                UpdatedValue.CategoryId
            );
            return View(UpdatedValue);
          
        }
        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto dto)
        {
            await _productService.UpdateProductAsync(dto);
            return RedirectToAction("ProductListWithCategory", "Product", new { Area = "Admin" });
        }

        public async Task<IActionResult> ProductListWithCategory()
        {
            ViewBag.MainTitle = "Ürün İşlemleri";
            ViewBag.Title1 = "Anasayfa";
            ViewBag.Title2 = "Ürünler";
            ViewBag.Title3 = "Ürün Listesi";

            var values = await _productService.GetProductWithCategoryAsync();
            return View(values);
        }
    }
}
