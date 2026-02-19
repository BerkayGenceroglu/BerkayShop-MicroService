using BerkayShop.DtoLayer.IdentityDtos.UserDtos;
using BerkayShop.WebUI.Models;

namespace BerkayShop.WebUI.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserDetailViewModel> GetUserInfo();
        Task<List<ResultUserDto>> GetAlluser();
    }
}
