namespace BerkayShop.WebUI.Services.StatisticServices.UserStatisticService
{
    public interface IUserStatisticService
    {
        Task<int> GetUserCount();
    }
}
