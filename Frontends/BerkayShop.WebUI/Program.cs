using BerkayShop.WebUI.Handlers;
using BerkayShop.WebUI.Services;
using BerkayShop.WebUI.Services.BasketServices;
using BerkayShop.WebUI.Services.CargoServices.CargoCompanyServices;
using BerkayShop.WebUI.Services.CargoServices.CargoCustomerServices;
using BerkayShop.WebUI.Services.CatalogServices.AboutService;
using BerkayShop.WebUI.Services.CatalogServices.BrandService;
using BerkayShop.WebUI.Services.CatalogServices.CategoryServices;
using BerkayShop.WebUI.Services.CatalogServices.ContactService;
using BerkayShop.WebUI.Services.CatalogServices.FeatureServices;
using BerkayShop.WebUI.Services.CatalogServices.FeatureSliderService;
using BerkayShop.WebUI.Services.CatalogServices.OfferDiscountService;
using BerkayShop.WebUI.Services.CatalogServices.ProductDetailService;
using BerkayShop.WebUI.Services.CatalogServices.ProductImageService;
using BerkayShop.WebUI.Services.CatalogServices.ProductServices;
using BerkayShop.WebUI.Services.CatalogServices.SpecialOfferService;
using BerkayShop.WebUI.Services.CommentServices;
using BerkayShop.WebUI.Services.Concrete;
using BerkayShop.WebUI.Services.DiscountServices;
using BerkayShop.WebUI.Services.Interfaces;
using BerkayShop.WebUI.Services.MessageServices;
using BerkayShop.WebUI.Services.OrderServices.OrderAddressService;
using BerkayShop.WebUI.Services.OrderServices.OrderAllOrderingService;
using BerkayShop.WebUI.Services.OrderServices.OrderOrderingService;
using BerkayShop.WebUI.Services.StatisticServices.CargoStatisticService;
using BerkayShop.WebUI.Services.StatisticServices.CatalogStatisticService;
using BerkayShop.WebUI.Services.StatisticServices.CommentStatisticService;
using BerkayShop.WebUI.Services.StatisticServices.DiscountCouponService;
using BerkayShop.WebUI.Services.StatisticServices.MessageStatisticService;
using BerkayShop.WebUI.Services.StatisticServices.OrderStatisticService;
using BerkayShop.WebUI.Services.StatisticServices.UserStatisticService;
using BerkayShop.WebUI.Settings;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc.Razor;
using Newtonsoft.Json.Linq;
using System;
using System.ComponentModel;
using System.Numerics;
using System.Reflection;
using System.Runtime.ConstrainedExecution;
using System.Runtime.Intrinsics.X86;

var builder = WebApplication.CreateBuilder(args);


//"Bu uygulamada Token Bazl? kimlik do?rulama kullanaca??m"
//"Kimlik do?rulama bilgilerini cookie'de saklayaca??m" der.“JWT’den gelen bilgileri alama taray?c?da COOKIE olarak sakla”
//“Eğer bir gün SignInAsync çağrılırsa
/// Bu kod, kullanıcı giriş/çıkış işlemlerini cookie üzerinden yöneten, güvenli ve kontrollü bir authentication altyapısı kurar.
//builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddCookie(JwtBearerDefaults.AuthenticationScheme, opt =>
//{
//    opt.LoginPath = "/Login/LoginPage";
//    opt.LogoutPath = "/Login/Logout";
//    opt.AccessDeniedPath = "/Pages/AccessDenied";
//    opt.Cookie.HttpOnly = true;
//    opt.Cookie.SameSite = SameSiteMode.Strict;
//    //“Bu cookie ba?ka sitelerden gönderilemez”
//    opt.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
//    opt.Cookie.Name = "BerkayShopWebUIAuthCookie"; /*Kullan?c?n?n giri? bilgisini bu isimle sakla*/
//});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, opt =>
{
    opt.LoginPath = "/Login/LoginPage";
    opt.ExpireTimeSpan = TimeSpan.FromDays(5);
    opt.Cookie.Name = "BerkayShopCookie";
    opt.SlidingExpiration = true;
});

builder.Services.AddHttpContextAccessor();

builder.Services.AddScoped<ILoginService,LoginService>();
builder.Services.AddHttpClient<IIdentityService,IdentityService>();

builder.Services.AddHttpClient();
builder.Services.AddControllersWithViews();

builder.Services.Configure<ClientSettings>(builder.Configuration.GetSection("ClientSettings"));
builder.Services.Configure<ServiceApiSettings>(builder.Configuration.GetSection("ServiceApiSettings"));

builder.Services.AddScoped<IClientCredentialTokenService, ClientCredentialTokenService>();
builder.Services.AddScoped<ResourceOwnerPasswordTokenHandler>();
builder.Services.AddScoped<ClientCredentialTokenHandler>();
//Servislere kaydeder, istendiğinde verir (request başına 1 kez).

var values = builder.Configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();

builder.Services.AddHttpClient<IUserService, UserService>(opt =>
{
    opt.BaseAddress = new Uri(values.IdentityServerUrl);
}).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();
//📌 ASP.NET Core şunu yapıyor:
//HttpClient’ı kendisi oluşturuyor
//Senin verdiğin ayarlarla dolduruyor
//Constructor’dan içeri sokuyor
//https://localhost:5001/api/user/getuser
//API’ye giden HER isteğin arasına ResourceOwnerPasswordTokenHandler’ı koyar

builder.Services.AddHttpClient<ICategoryService, CategoryService>(opt =>
{
        //“ICategoryService istendiğinde,
        //arka planda CategoryService oluştur
        //ve içine otomatik olarak ayarlı bir HttpClient ver
    opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Catalog.Path}");
}).AddHttpMessageHandler<ClientCredentialTokenHandler>();
//“Bu HttpClient ile her istek atılmadan önce,
//ResourceOwnerPasswordTokenHandler çalışsın”
//AddHttpClient, .NET (ASP.NET Core) uygulamalarında dış servislerle (API'lerle) haberleşmek için kullanılan HttpClient nesnelerini merkezi ve güvenli bir şekilde yönetmenizi sağlayan bir metodur.


//PasswordTokenHandler-Kullanıcı Login Olmak Zorunda
builder.Services.AddHttpClient<IBasketService, BasketService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Basket.Path}");
}).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

builder.Services.AddHttpClient<IOrderOrderingService, OrderOrderingService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Order.Path}");
}).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();


builder.Services.AddHttpClient<IOrderAddressService, OrderAddressService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Order.Path}");
}).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

builder.Services.AddHttpClient<ICouponStatisticService, CouponStatisticService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Discount.Path}");
}).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();


builder.Services.AddHttpClient<IDiscountService, DiscountService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Discount.Path}");
}).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

builder.Services.AddHttpClient<IOrderStatisticService, OrderStatisticService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Order.Path}");
}).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

builder.Services.AddHttpClient<IMessageService, MessageService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Message.Path}");
}).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

builder.Services.AddHttpClient<IUserStatisticService, UserStatisticService>(opt =>
{
    opt.BaseAddress = new Uri(values.IdentityServerUrl);
}).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

builder.Services.AddHttpClient<ICargoCompanyService, CargoCompanyService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Cargo.Path}");
}).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

builder.Services.AddHttpClient<ICargoStatisticService, CargoStatisticService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Cargo.Path}");
}).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

builder.Services.AddHttpClient<ICargoCustomerService, CargoCustomerService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Cargo.Path}");
}).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

builder.Services.AddHttpClient<ICatalogStatisticService, CatalogStatisticService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Catalog.Path}");
}).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

builder.Services.AddHttpClient<ICommentStatisticService, CommentStatisticService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Comment.Path}");
}).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

builder.Services.AddHttpClient<IMessageStatisticService, MessageStatisticService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Message.Path}");
}).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

builder.Services.AddHttpClient<IOrderingService, OrderingService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Order.Path}");
}).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

//ClientCredentialTokenHandler -- Kullanıcı Login Olmadan Erişebilir
//Ocelot Url + Catalog Path
builder.Services.AddHttpClient<IProductService, ProductService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Catalog.Path}");
}).AddHttpMessageHandler<ClientCredentialTokenHandler>();


builder.Services.AddHttpClient<ISpecialOfferService, SpecialOfferService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Catalog.Path}");
}).AddHttpMessageHandler<ClientCredentialTokenHandler>();

builder.Services.AddHttpClient<IFeatureSliderService, FeatureSliderService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Catalog.Path}");
}).AddHttpMessageHandler<ClientCredentialTokenHandler>();

builder.Services.AddHttpClient<IFeatureService, FeatureService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Catalog.Path}");
}).AddHttpMessageHandler<ClientCredentialTokenHandler>();

builder.Services.AddHttpClient<IOfferDiscountService, OfferDiscountService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Catalog.Path}");
}).AddHttpMessageHandler<ClientCredentialTokenHandler>();

builder.Services.AddHttpClient<IBrandService, BrandService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Catalog.Path}");
}).AddHttpMessageHandler<ClientCredentialTokenHandler>();

builder.Services.AddHttpClient<IAboutService, AboutService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Catalog.Path}");
}).AddHttpMessageHandler<ClientCredentialTokenHandler>();

builder.Services.AddHttpClient<IContactService, ContactService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Catalog.Path}");
}).AddHttpMessageHandler<ClientCredentialTokenHandler>();

builder.Services.AddHttpClient<IProductDetailService, ProductDetailService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Catalog.Path}");
}).AddHttpMessageHandler<ClientCredentialTokenHandler>();

builder.Services.AddHttpClient<IProductImageService, ProductImageService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Catalog.Path}");
}).AddHttpMessageHandler<ClientCredentialTokenHandler>();

builder.Services.AddHttpClient<ICommentService, CommentService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Comment.Path}");
}).AddHttpMessageHandler<ClientCredentialTokenHandler>();

builder.Services.AddLocalization(opt =>
{
    opt.ResourcesPath = "Resources"; /*Çeviri dosyalarım Resources klasörünün içinde olacak.*/
});
// Localization servisini DI container'a ekler. ResourcesPath = "Resources" diyerek çeviri dosyalarının (.resx) projedeki Resources klasöründe aranacağını belirtiyorsun.

builder.Services.AddMvc()
    .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix) /*View dosyalarının dil versiyonlarını arar.*/
    .AddDataAnnotationsLocalization();/* Model içindeki validation mesajlarını çevirir.*/
//AddViewLocalization, Razor View'larda localization kullanımını aktif eder. Suffix formatı şu anlama gelir: View dosyası için dil bazlı kaynak dosyasını ismine suffix (son ek) ekleyerek arar. Örneğin Index.tr.resx, Index.en.resx gibi.
//AddDataAnnotationsLocalization, model üzerindeki attribute'ların ([Required], [MaxLength] gibi) hata mesajlarını da loca    
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
//?? Bu kod ?unu yapar:
//“Her gelen istekte, az önce tan?mlad???m kurallara göre kullan?c?y? kontrol et.”
//Cookie var m??
//Login mi?
//Claim’leri yükle
//?? ASIL KONTROL burada ba?lar.
app.UseAuthorization();

var supportedCultures = new[] { "en","fr","de","it","tr"}; /*Benim uygulamam bu 4 dili destekliyor.*/
var localizationOptions = new RequestLocalizationOptions().SetDefaultCulture(supportedCultures[3])/*Eğer kullanıcı bir dil seçmezse varsayılan dil Türkçe olsun.*/
    .AddSupportedCultures(supportedCultures)/*Uygulamanın:Tarih formatı Para birimi Sayı formatı gibi kültürel ayarlarını belirler.*/
    .AddSupportedUICultures(supportedCultures); /*Yani resource dosyalarının dili.*/

app.UseRequestLocalization(localizationOptions); /*Gelen HTTP isteğine göre culture belirler ve localization sistemini çalıştırır.*/

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();
