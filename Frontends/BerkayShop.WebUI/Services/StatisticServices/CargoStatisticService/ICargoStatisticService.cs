namespace BerkayShop.WebUI.Services.StatisticServices.CargoStatisticService
{
    public interface ICargoStatisticService
    {
        Task<int> GetTotalCargoCompanyCount();
    }
}
