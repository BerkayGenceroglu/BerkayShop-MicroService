using BerkayShop.DtoLayer.CatalogDtos.CategoryDtos;
using BerkayShop.WebUI.Services.CatalogServices.CategoryServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BerkayShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[Controller]/[Action]/{id?}")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IActionResult> CategoryList()
        {
            ViewBag.MainTitle = "Kategori İşlemleri";
            ViewBag.Title1 = "Anasayfa";
            ViewBag.Title2 = "Kategoriler";
            ViewBag.Title3 = "Kategori Listesi";
            var values =await _categoryService.GetAllCategoryAsync();
            return View(values);

        }
        [HttpGet]
        public IActionResult AddCategory()
        {
            ViewBag.MainTitle = "Kategori İşlemleri";
            ViewBag.Title1 = "Anasayfa";
            ViewBag.Title2 = "Kategoriler";
            ViewBag.Title3 = "Kategori Ekle";

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddCategory(CreateCategoryDto createCategoryDto)
        {
            await _categoryService.CreateCategoryAsync(createCategoryDto);   
            return RedirectToAction("CategoryList","Category",new { Area ="Admin"});
           
        }
        public async Task<IActionResult> RemoveCategory(string id)
        {
            await _categoryService.DeleteCategoryAsync(id);
            return RedirectToAction("CategoryList", "Category", new { Area = "Admin" });
        }

        [HttpGet]
        public async Task<IActionResult> UpdateCategory(string id)
        {
            ViewBag.MainTitle = "Kategori İşlemleri";
            ViewBag.Title1 = "Anasayfa";
            ViewBag.Title2 = "Kategoriler";
            ViewBag.Title3 = "Kategori Güncelle";

            var value = await _categoryService.GetByIdCategoryAsync(id);
            var updateValue = new UpdateCategoryDto
            {
                CategoryName = value.CategoryName,
                CategoryId = value.CategoryId,
                ImageUrl = value.ImageUrl
            };
            return View(updateValue);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto dto)
        {
           await _categoryService.UpdateCategoryAsync(dto);
           return RedirectToAction("CategoryList", "Category", new { Area = "Admin" });
       
        }
    }
}
