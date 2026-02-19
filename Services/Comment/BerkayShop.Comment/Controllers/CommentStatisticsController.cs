using BerkayShop.Comment.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BerkayShop.Comment.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class CommentStatisticsController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentStatisticsController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetTotalComment()
        {
            var TotalComment = await _commentService.GetTotalCommentCountAsync();
            return Ok(TotalComment);
        }
    }
}
