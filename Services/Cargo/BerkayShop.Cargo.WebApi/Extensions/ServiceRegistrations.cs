using BerkayShop.Cargo.BusinessLayer.Abstract;
using BerkayShop.Cargo.BusinessLayer.Concrete;
using BerkayShop.Cargo.DataAccessLayer.Abstract;
using BerkayShop.Cargo.DataAccessLayer.Concrete;
using BerkayShop.Cargo.DataAccessLayer.EntityFramework;
using System.Reflection;

namespace BerkayShop.Cargo.WebApi.Extensions
{
    public static class ServiceRegistrations
    {
        public static void AddCargoServices(this IServiceCollection services)
        {
            //Context
            services.AddDbContext<CargoContext>();

            //Services
            services.AddScoped<ICargoCompanyDal, EfCargoCompanyDal>();
            services.AddScoped<ICargoCompanyService,CargoCompanyManager>();

            services.AddScoped<ICargoDetailDal, EfCargoDetailDal>();
            services.AddScoped<ICargoDetailService, CargoDetailManager>();

            services.AddScoped<ICargoCustomerDal, EfCargoCustomerDal>();
            services.AddScoped<ICargoCustomerService, CargoCustomerManager>();

            services.AddScoped<ICargoOperationDal, EfCargoOperationDal>();
            services.AddScoped<ICargoOperationService, CargoOperationManager>();

            //Mapping
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
        }
    }
}
