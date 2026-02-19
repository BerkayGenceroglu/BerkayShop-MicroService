using BerkayShop.Discount.Dtos;

namespace BerkayShop.Discount.Services
{
    public interface IDiscountService
    {
        Task<List<ResultDiscountDto>> GetAllDiscountAsync();
        Task CreateDiscountAsync(CreateDiscountDto createDiscountDto);
        Task UpdateDiscountAsync(UpdateDiscountDto updateDiscountDto);
        Task DeleteDiscountAsync(int id);
        Task<GetByIdDiscountDto> GetByIdDiscountAsync(int id);
        Task<ResultDiscountDto> GetCodeDetailByCodeAsync(string code);
        Task<int> GetDiscountCouponCountAsync();
    }
}
