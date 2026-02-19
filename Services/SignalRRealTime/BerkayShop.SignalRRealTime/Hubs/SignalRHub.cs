using BerkayShop.SignalRRealTime.Services.SignalRCommentService;
using BerkayShop.SignalRRealTime.Services.SignalRMessageService;
using Microsoft.AspNetCore.SignalR;

namespace BerkayShop.SignalRRealTime.Hubs
{
    public class SignalRHub: Hub
    {
        private readonly ISignalRCommentService _signalRCommentService;
        private readonly ISignalRMessageService _signalRMessageService;

        public SignalRHub(ISignalRCommentService signalRCommentService, ISignalRMessageService signalRMessageService)
        {
            _signalRCommentService = signalRCommentService;
            _signalRMessageService = signalRMessageService;
        }

        public async Task SendStatistics(string receiverId)
        {
            var TotalCommentCount = await _signalRCommentService.GetTotalCommentCountAsync();
            await Clients.All.SendAsync("ReceiverTotalCommentCount", TotalCommentCount);

            var TotalMessageCount = await _signalRMessageService.GetMessageCountByUserId(receiverId);
            await Clients.All.SendAsync("ReceiverTotalMessageCount", TotalMessageCount);
        }
    }
}
