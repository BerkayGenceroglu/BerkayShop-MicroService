using BerkayShop.Message.Dtos;

namespace BerkayShop.Message.Services
{
    public interface IUserMessageService
    {
        Task<List<ResultMessageDto>> GetAllMessageAsync();
        Task<List<ResultInboxMessageDto>> GetAllInboxMessageAsync(string receiverId);
        Task<List<ResultSendboxMessageDto>> GetAllSendboxMessageAsync(string senderId);
        Task CreateMessageAsync(CreateMessageDto createMessageDto);
        Task UpdateMessageAsync(UpdateMessageDto updateMessageDto);
        Task DeleteMessageAsync(int id);
        Task<ResultMessageDto> GetMessageByIdAsync(int id);
        Task<int> GetTotalMessageCount();
        Task<int> GetMessageCountByUserId(string receiverId);
    }
}
