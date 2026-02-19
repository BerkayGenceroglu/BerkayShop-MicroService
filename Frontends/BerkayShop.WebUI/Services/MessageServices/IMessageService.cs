using BerkayShop.DtoLayer.MessageDtos;

namespace BerkayShop.WebUI.Services.MessageServices
{
    public interface IMessageService
    {
        Task<List<ResultInboxMessageDto>> GetAllInboxMessageAsync(string receiverId);
        Task<List<ResultSendBoxMessageDto>> GetAllSendboxMessageAsync(string senderId);
        Task<int> GetMessageCountByUserId(string receiverId);
    }
}
