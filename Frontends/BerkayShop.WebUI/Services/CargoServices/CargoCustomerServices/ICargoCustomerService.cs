using BerkayShop.DtoLayer.CargoDtos.CargoCustomerDtos;

namespace BerkayShop.WebUI.Services.CargoServices.CargoCustomerServices
{
    public interface ICargoCustomerService
    {
        Task<GetCargoCustomerByUserIdDto> GetCargoCustomerByUserIdAsync(string userId);
    }
}
