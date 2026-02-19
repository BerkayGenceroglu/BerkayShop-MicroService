namespace BerkayShop.SignalRRealTime.Services.SignalRCommentService
{
    public interface ISignalRCommentService
    {
        Task<int> GetTotalCommentCountAsync();
    }
}
