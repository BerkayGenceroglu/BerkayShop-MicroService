using BerkayShop.DtoLayer.CommentDtos.CommentDtos;
using BerkayShop.WebUI.Services.CommentServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BerkayShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[Controller]/[Action]/{id?}")]
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public async Task<IActionResult> CommentList()
        {
            ViewBag.MainTitle = "Yorum İşlemleri";
            ViewBag.Title1 = "Anasayfa";
            ViewBag.Title2 = "Yorumlar";
            ViewBag.Title3 = "Yorum Listesi";
            
            var values = await _commentService.GetAllCommentAsync();
            return View(values);
        }

        public async Task<IActionResult> RemoveComment(int id)
        {
            await _commentService.DeleteCommentAsync(id);
            return RedirectToAction("CommentList", "Comment", new { Area = "Admin" });
        }

        [HttpGet]
        public async Task<IActionResult> UpdateComment(int id)
        {
            ViewBag.MainTitle = "Yorum İşlemleri";
            ViewBag.Title1 = "Anasayfa";
            ViewBag.Title2 = "Yorumlar";
            ViewBag.Title3 = "Yorum Güncelle";

            var value = await _commentService.GetByIdCommentAsync(id);
            var updateValue = new UpdateCommentDto
            {
                UserCommentId = value.UserCommentId,
                NameSurname = value.NameSurname,
                Email = value.Email,
                ImageUrl = value.ImageUrl,
                CommentDetail = value.CommentDetail,
                Rating = value.Rating,
                CreatedDate = value.CreatedDate,
                Status = value.Status,
                ProductId = value.ProductId,

            };
            return View(updateValue);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateComment(UpdateCommentDto dto)
        {
            await _commentService.UpdateCommentAsync(dto);
            return RedirectToAction("CommentList", "Comment", new { Area = "Admin" });
        }

    }
}
