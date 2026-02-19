namespace BerkayShop.WebUI.Services.StatisticServices.OrderStatisticService
{
    public interface IOrderStatisticService
    {
        Task<decimal> GetOrderingTotalPrice();
        Task<DateTime> GetLastOrderDate();
    }
}
