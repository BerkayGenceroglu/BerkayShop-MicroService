using BerkayShop.Basket.Dtos;

namespace BerkayShop.Basket.Services
{
    public interface IBasketService
    {
        Task<BasketTotalDto> GetBasket(string userId);
        Task DeleteBasket(string userId);
        Task SaveBasket(BasketTotalDto basketTotalDto);   
    }
}
