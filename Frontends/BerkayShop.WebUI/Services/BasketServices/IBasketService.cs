using BerkayShop.DtoLayer.BasketDtos;

namespace BerkayShop.WebUI.Services.BasketServices
{
    public interface IBasketService
    {
        Task<BasketTotalDto> GetBasket();
        Task DeleteBasket(string userId);
        Task SaveBasket(BasketTotalDto basketTotalDto);
        Task AddBasketItem(BasketItemDto basketItemDto);
        Task<bool> RemoveBasketItem( string productId);
    }
}
