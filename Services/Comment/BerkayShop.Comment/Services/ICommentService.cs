using BerkayShop.Comment.Dtos.CommentDto;

namespace BerkayShop.Comment.Services
{
    public interface ICommentService
    {
        Task<List<ResultCommentDto>> GetAllCommentAsync();
        Task CreateCommentAsync(CreateCommentDto createCommentDto);
        Task UpdateCommentAsync(UpdateCommentDto updateCommentDto);
        Task DeleteCommentAsync(int id);
        Task<GetByIdCommentDto> GetByIdCommentAsync(int id);
        Task<List<ResultCommentDto>> GetByProductIdCommentAsync(string productId);
        Task<int> GetActiveCommentCountAsync();
        Task<int> GetPassiveCommentCountAsync();
        Task<int> GetTotalCommentCountAsync();
    }
}
