using BerkayShop.DtoLayer.OrderDtos.OrderOrderingDto;

namespace BerkayShop.WebUI.Services.OrderServices.OrderOrderingService
{
    public interface IOrderOrderingService
    {
        Task<List<GetOrderingByUserIdDto>> GetOrderingByUserIdAsync(string userId);
    }
}
