using BerkayShop.DtoLayer.CommentDtos.CommentDtos;

namespace BerkayShop.WebUI.Services.CommentServices
{
    public class CommentService : ICommentService
    {
        private readonly HttpClient _httpClient;

        public CommentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateCommentAsync(CreateCommentDto createCommentDto)
        {
            await _httpClient.PostAsJsonAsync("Comments", createCommentDto);
        }

        public async Task DeleteCommentAsync(int id)
        {
            await _httpClient.DeleteAsync($"Comments/{id}");
        }

        public async Task<List<ResultCommentDto>> GetAllCommentAsync()
        {
            var values = await _httpClient.GetFromJsonAsync<List<ResultCommentDto>>("Comments");
            return values;
        }

        public async Task<GetByIdCommentDto> GetByIdCommentAsync(int id)
        {
            var value = await _httpClient.GetFromJsonAsync<GetByIdCommentDto>($"Comments/{id}");
            return value!;
        }

        public async Task<List<ResultCommentDto>> GetByProductIdCommentAsync(string productId)
        {
            var values = await _httpClient.GetFromJsonAsync<List<ResultCommentDto>>($"Comments/GetByProductIdComment/{productId}");
            return values!;
        }

        public async Task UpdateCommentAsync(UpdateCommentDto updateCommentDto)
        {
            await _httpClient.PutAsJsonAsync("Comments", updateCommentDto);
        }
    }
}
