namespace BerkayShop.WebUI.Services.StatisticServices.CommentStatisticService
{
    public interface ICommentStatisticService
    {
        Task<int> GetActiveCommentCountAsync();
        Task<int> GetPassiveCommentCountAsync();
        Task<int> GetTotalCommentCountAsync();
    }
}
