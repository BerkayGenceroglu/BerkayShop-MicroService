using BerkayShop.DtoLayer.MessageDtos;
using NuGet.Protocol.Plugins;

namespace BerkayShop.WebUI.Services.MessageServices
{
    public class MessageService : IMessageService
    {
        private readonly HttpClient _httpClient;

        public MessageService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ResultInboxMessageDto>> GetAllInboxMessageAsync(string receiverId)
        {
            var values = await _httpClient.GetFromJsonAsync<List<ResultInboxMessageDto>>($"http://localhost:5000/services/message/messages/GetMessageForInbox/{receiverId}");
            return values!;
        }

        public async Task<List<ResultSendBoxMessageDto>> GetAllSendboxMessageAsync(string senderId)
        {
            var values = await _httpClient.GetFromJsonAsync<List<ResultSendBoxMessageDto>>($"http://localhost:5000/services/message/messages/GetMessageForSendbox/{senderId}");
            return values!;
        }

        public async Task<int> GetMessageCountByUserId(string receiverId)
        {
            return await _httpClient.GetFromJsonAsync<int>($"Messages/GetMessageCountByUserId/{receiverId}")!;
        }
        
    }
}
