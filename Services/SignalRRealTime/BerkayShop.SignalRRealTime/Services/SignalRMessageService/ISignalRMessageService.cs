namespace BerkayShop.SignalRRealTime.Services.SignalRMessageService
{
    public interface ISignalRMessageService
    {
        Task<int> GetMessageCountByUserId(string receiverId);
    }
}
