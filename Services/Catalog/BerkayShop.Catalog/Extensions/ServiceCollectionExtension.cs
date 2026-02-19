using BerkayShop.Catalog.Services.AboutServices;
using BerkayShop.Catalog.Services.BrandServices;
using BerkayShop.Catalog.Services.CategoryServices;
using BerkayShop.Catalog.Services.ContactServices;
using BerkayShop.Catalog.Services.FeatureServices;
using BerkayShop.Catalog.Services.FeatureSliderServices;
using BerkayShop.Catalog.Services.OfferDiscountServices;
using BerkayShop.Catalog.Services.ProductDetailServices;
using BerkayShop.Catalog.Services.ProductImageServices;
using BerkayShop.Catalog.Services.ProductServices;
using BerkayShop.Catalog.Services.SpecialOfferServices;
using BerkayShop.Catalog.Services.StatisticService;
using BerkayShop.Catalog.Settings;
using Microsoft.Extensions.Options;
using System.Reflection;
using System.Runtime.ConstrainedExecution;

namespace BerkayShop.Catalog.Extensions
{
    public static class ServiceCollectionExtension
    {
        //This IserviceCollection:"Zaten var olan servis koleksiyonunu bana ver, ben ona eklemeler yapacağım"
        //Iconfiguration:"Ayrıca bana appsettings.json okuma nesnesini de ver, ayarları okumam lazım"
        public static IServiceCollection AddCatalogServices(this IServiceCollection Services,IConfiguration Configuration)
        {
            //Database Settings
            Services.Configure<DatabaseSetting>(
              Configuration.GetSection("DatabaseSettings"));
            //“appsettings’teki DatabaseSettings’i al, ayar nesnesine bağla.”
            //appsettings.json'dan "DatabaseSettings" bölümünü oku ve DatabaseSetting sınıfına bağla.
            Services.AddScoped<IDatabaseSettings>(sp =>
            {
                return sp.GetRequiredService<IOptions<DatabaseSetting>>().Value;
                //“Biri IDatabaseSettings isterse,
                //DI kutusundan ayarları al,
                //paketi aç(.Value),
                //her request için ona ver.”
            });


            //AutoMapper    
            Services.AddAutoMapper(Assembly.GetExecutingAssembly());
            //"Zaten var olan servis koleksiyonuna, AutoMapper'ı ekle. Bu projede (Assembly) bulunan tüm mapping profillerini bul
            //ve koleksiyona kaydet

            //Services
            Services.AddScoped<IProductService, ProductService>();
            Services.AddScoped<IProductDetailService, ProductDetailService>();
            Services.AddScoped<IProductImageService, ProductImageService>();
            Services.AddScoped<ICategoryService, CategoryService>();
            Services.AddScoped<IFeatureSliderService, FeatureSliderService>();
            Services.AddScoped<ISpecialOfferService, SpecialOfferService>();
            Services.AddScoped<IFeatureService, FeatureService>();
            Services.AddScoped<IOfferDiscountService, OfferDiscountService>();
            Services.AddScoped<IBrandService, BrandService>();
            Services.AddScoped<IAboutService, AboutService>();
            Services.AddScoped<IContactService, ContactService>();
            Services.AddScoped<IStatisticService, StatisticService>();

            return Services;
        }
    }
}
//"Bu metod, zaten var olan servis koleksiyonunu alıyor, içine 7 farklı servis/ayar ekliyor (Database ayarları, AutoMapper, 4 iş servisi), ve aynı koleksiyonu geri döndürüyor. Böylece Program.cs'te zincirleme metod çağrıları yapabiliyoruz