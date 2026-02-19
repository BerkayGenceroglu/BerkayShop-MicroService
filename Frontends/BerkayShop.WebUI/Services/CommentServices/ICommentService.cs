using BerkayShop.DtoLayer.CommentDtos.CommentDtos;

namespace BerkayShop.WebUI.Services.CommentServices
{
    public interface ICommentService
    {
        Task<List<ResultCommentDto>> GetAllCommentAsync();
        Task CreateCommentAsync(CreateCommentDto createCommentDto);
        Task UpdateCommentAsync(UpdateCommentDto updateCommentDto);
        Task DeleteCommentAsync(int id);
        Task<GetByIdCommentDto> GetByIdCommentAsync(int id);
        Task<List<ResultCommentDto>> GetByProductIdCommentAsync(string productId);
    }
}
