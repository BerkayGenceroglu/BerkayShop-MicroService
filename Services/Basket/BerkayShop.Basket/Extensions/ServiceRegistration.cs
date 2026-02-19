using BerkayShop.Basket.LoginServices;
using BerkayShop.Basket.Services;
using BerkayShop.Basket.Setttings;

namespace BerkayShop.Basket.Extensions
{
    public static class ServiceRegistration
    {
        public static void AddBasketServices(this IServiceCollection services)
        {
            //HttpContext'e erişim için gerekli servis kaydı
            services.AddHttpContextAccessor();

            //AddScoped
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<IBasketService, BasketService>();
           
        }
    }
}
