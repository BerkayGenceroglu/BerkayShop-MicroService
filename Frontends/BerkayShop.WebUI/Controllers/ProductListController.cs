using BerkayShop.DtoLayer.CommentDtos.CommentDtos;
using BerkayShop.WebUI.Services.CommentServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;

namespace BerkayShop.WebUI.Controllers
{
    public class ProductListController : Controller
    {
        private readonly ICommentService _commentService;

        public ProductListController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public IActionResult AllProductList(string categoryId)
        {
            ViewBag.Directory1 = "BerkayShop";
            ViewBag.Directory2 = "Ürünler";
            ViewBag.Directory3 = "Ürün Listesi";
            return View("AllProductList",categoryId);
        }
        public IActionResult ProductDetail(string productId)
        {
            ViewBag.Directory1 = "BerkayShop";
            ViewBag.Directory2 = "Ürünler";
            ViewBag.Directory3 = "Ürün Detayları";
            return View("ProductDetail", productId);
        }
    
        public async Task<IActionResult> AddComment(CreateCommentDto dto)
        {
            dto.CreatedDate = DateTime.Parse(DateTime.Now.ToString("dd.MM.yyyy"));
            dto.Status = false;

            await _commentService.CreateCommentAsync(dto);
            return RedirectToAction("ProductDetail", "ProductList", new { productId=dto.ProductId});
        }
    }
}
