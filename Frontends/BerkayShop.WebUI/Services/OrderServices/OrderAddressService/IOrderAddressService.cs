using BerkayShop.DtoLayer.OrderDtos.OrderAddressDto;

namespace BerkayShop.WebUI.Services.OrderServices.OrderAddressService
{
    public interface IOrderAddressService
    {
        Task CreateOrderAddressAsync(CreateOrderAddressDto createOrderAddressDto);
    }
}
