using BerkayShop.DtoLayer.CommentDtos.CommentDtos;
using BerkayShop.WebUI.Services.CommentServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BerkayShop.WebUI.ViewComponents.ProductDetailViewComponentPartial
{
    public class _ReviewsProductDetailComponentPartial : ViewComponent
    {
        private readonly ICommentService _commentService;

        public _ReviewsProductDetailComponentPartial(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string productId)
        {
            var value = await _commentService.GetByProductIdCommentAsync(productId);
            return View(value);
        }
    }
}
