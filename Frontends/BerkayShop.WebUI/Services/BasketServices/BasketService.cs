using BerkayShop.DtoLayer.BasketDtos;

namespace BerkayShop.WebUI.Services.BasketServices
{
    public class BasketService : IBasketService
    {
        private readonly HttpClient _httpClient;

        public BasketService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task AddBasketItem(BasketItemDto basketItemDto)
        {
            var basket = await GetBasket();
            var existingItem = basket.BasketItems.FirstOrDefault(x => x.ProductId == basketItemDto.ProductId);
            if (existingItem == null)
            {
                basket.BasketItems.Add(basketItemDto);
            }
            else
            {
               existingItem.Quantity += basketItemDto.Quantity;
            }
            await SaveBasket(basket);
        }

        public async Task DeleteBasket(string userId)
        {
            await _httpClient.DeleteAsync("baskets");
        }

        public async Task<BasketTotalDto> GetBasket()
        {
            var values = await _httpClient.GetFromJsonAsync<BasketTotalDto>("baskets");
            return values;
        }

        public async Task<bool> RemoveBasketItem(string productId)
        {
            var basket = await GetBasket();
            var deletedItem = basket.BasketItems.FirstOrDefault(x => x.ProductId == productId);
            basket.BasketItems.Remove(deletedItem!);
            await SaveBasket(basket);
            return true;
        }

        public async Task SaveBasket(BasketTotalDto basketTotalDto)
        {
            await _httpClient.PostAsJsonAsync("baskets",basketTotalDto);
        }
    }
}
