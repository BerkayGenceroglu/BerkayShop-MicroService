using BerkayShop.DtoLayer.OrderDtos.OrderAllOrderDto;

namespace BerkayShop.WebUI.Services.OrderServices.OrderAllOrderingService
{
    public interface IOrderingService
    {
        Task<List<GetAllOrderDto>> GetAllOrder();
    }
}
