using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

//IConfiguration: Uygulama ayarlarını (configuration) okumak için kullanılan bir arayüz (interface). JSON, XML gibi kaynaklardan ayarları tutabilir.
//ConfigurationBuilder: Configuration nesnesi oluşturmak için kullanılan bir sınıf. Hangi dosyalardan ayar okunacağını belirler.
//Build(): ConfigurationBuilder'ın topladığı tüm ayarları alıp, kullanıma hazır bir IConfiguration nesnesi oluşturur.
IConfiguration Configuration = new ConfigurationBuilder().AddJsonFile("ocelot.json").Build();

builder.Services.AddOcelot(Configuration);
//: "Ocelot'u servislere kaydet ve ona bu ayarları kullan" demek.

builder.Services.AddAuthentication().AddJwtBearer("OcelotAuthenticationScheme", opt =>
{
    opt.Authority = builder.Configuration["IdentityServerURL"]; /*Kim bastı*/
    opt.RequireHttpsMetadata = false;
    opt.Audience = "ResourceOcelot"; /*Kim İçin*/
});
//-"Authority:“Bir kullanıcı uygulamaya girmek istediğinde, uygulamanız bu adrese gider ve "Bu kullanıcı geçerli mi?" diye teyit eder.Uygulamanızın güvenlik anahtarlarını ve giriş bilgilerini doğrulattığı merkezi şubenin adresidir.”"
//- "Token'ın `ResourceOcelot` için olması lazım"

var app = builder.Build();

app.UseAuthentication();
await app.UseOcelot();
//Artık gelen istekleri Ocelot yönetsin, routingi o yapsın
app.MapGet("/", () => "Hello World!");

app.Run();
