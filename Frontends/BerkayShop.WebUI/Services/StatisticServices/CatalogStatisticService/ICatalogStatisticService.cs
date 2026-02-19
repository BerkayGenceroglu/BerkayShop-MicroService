using BerkayShop.DtoLayer.StatisticDtos.CatalogStatisticDto;

namespace BerkayShop.WebUI.Services.StatisticServices.CatalogStatisticService
{
    public interface ICatalogStatisticService
    {
        //long, C#’ta çok büyük tam sayıları tutmak için kullanılan bir veri tipidir.
        Task<long> GetCategoryCount();
        Task<long> GetBrandCount();
        Task<long> GetProductCount();
        Task<decimal> GetProductAvgPrice();
        Task<string> GetMaxPriceProductName();
        Task<string> GetMinPriceProductName();
        Task<long> GetTotalDiscountCount();
    }
}
