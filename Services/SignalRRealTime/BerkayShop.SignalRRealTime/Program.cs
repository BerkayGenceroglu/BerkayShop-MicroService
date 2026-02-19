using BerkayShop.SignalRRealTime.Hubs;
using BerkayShop.SignalRRealTime.Services.SignalRCommentService;
using BerkayShop.SignalRRealTime.Services.SignalRMessageService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors(opt =>
{
    opt.AddPolicy("CorsPolicy", policy =>
    {
        policy.AllowAnyHeader(). //Frontend hangi header’ı gönderirse göndersin kabul eder.
               AllowAnyMethod() //Tüm HTTP methodlarına izin verir.
              .SetIsOriginAllowed(Host => true) //Hangi origin’den gelirse gelsin kabul eder. (localhost:3000, localhost:4200, localhost:8080 gibi)
              .AllowCredentials();//SignalR kullanırken CORS ayarlarında AllowCredentials() eklenmesi gerekir. Bu, SignalR'ın kimlik doğrulama bilgilerini (örneğin, çerezler) içeren istekleri kabul etmesini sağlar. Eğer bu ayar yapılmazsa, SignalR bağlantıları başarısız olabilir çünkü kimlik doğrulama bilgileri gönderilmez ve sunucu tarafından reddedilir.
    });
});

builder.Services.AddSignalR();
builder.Services.AddHttpClient();
builder.Services.AddScoped<ISignalRMessageService, SignalRMessageService>();
builder.Services.AddScoped<ISignalRCommentService, SignalRCommentService>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapHub<SignalRHub>("/Signalrhub");//“SignalRHub isimli hub’ı /signalrhub adresine bağladım.”

app.Run();
