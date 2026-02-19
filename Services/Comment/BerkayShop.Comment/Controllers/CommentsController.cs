using BerkayShop.Comment.Dtos.CommentDto;
using BerkayShop.Comment.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BerkayShop.Comment.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentsController(ICommentService commentService)
        {
            _commentService = commentService;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCommentsByProductId(int id)
        {
            var comments = await _commentService.GetByIdCommentAsync(id);
            return Ok(comments);
        }
        [HttpGet("GetByProductIdComment/{productId}")]
        public async Task<IActionResult> GetByProductIdComment(string productId)
        {
            var comments = await _commentService.GetByProductIdCommentAsync(productId);
            return Ok(comments);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllComments()
        {
            var comments = await _commentService.GetAllCommentAsync();
            return Ok(comments);
        }
        [HttpPost]
        public async Task<IActionResult> CreateComment(CreateCommentDto dto)
        {
            await _commentService.CreateCommentAsync(dto);
            return Ok("Ekleme İşlemi Başarıyla Gerçekleşti");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComment(int id)
        {
            await _commentService.DeleteCommentAsync(id);
            return Ok("Silme İşlemi Başarıyla Gerçekleşti");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateComment(UpdateCommentDto dto)
        {
            await _commentService.UpdateCommentAsync(dto);
            return Ok("Güncellleme İşlemi Başarıyla Gerçekleşti");
        }

        [HttpGet("GetActiveCommentCount")]
        public async Task<IActionResult> GetActiveCommentCount()
        {
            var count = await _commentService.GetActiveCommentCountAsync();
            return Ok(count);
        }

        [HttpGet("GetPassiveCommentCount")]
        public async Task<IActionResult> GetPassiveCommentCount()
        {
            var count = await _commentService.GetPassiveCommentCountAsync();
            return Ok(count);
        }
        [AllowAnonymous]
        [HttpGet("GetTotalCommentCount")]
        public async Task<IActionResult> GetTotalCommentCount()
        {
            var count = await _commentService.GetTotalCommentCountAsync();
            return Ok(count);
        }

    }
}
