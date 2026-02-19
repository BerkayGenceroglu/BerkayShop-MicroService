using BerkayShop.DtoLayer.IdentityDtos.LoginDtos;

namespace BerkayShop.WebUI.Services.Interfaces
{
	public interface IIdentityService
	{
		Task<bool> SignIn(SignInDto signInDto);
		Task<bool> GetRefreshToken();
    }
}
