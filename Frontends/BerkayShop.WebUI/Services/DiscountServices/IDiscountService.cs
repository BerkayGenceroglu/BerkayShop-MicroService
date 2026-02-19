using BerkayShop.DtoLayer.DiscountDtos;

namespace BerkayShop.WebUI.Services.DiscountServices
{
    public interface IDiscountService
    {
        Task<GetDiscountCodeDetailByCode> GetDiscountCode(string code);
    }
}
