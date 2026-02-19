namespace BerkayShop.Catalog.Services.StatisticService
{
    public interface IStatisticService
    {
        //long, C#’ta çok büyük tam sayıları tutmak için kullanılan bir veri tipidir.
        long GetCategoryCount();
        long GetBrandCount();
        long GetProductCount();
        long GetTotalDiscountCount();
        Task<decimal> GetProductAvgPrice();
        Task<string> GetMaxPriceProductName();
        Task<string> GetMinPriceProductName();
    }
}
