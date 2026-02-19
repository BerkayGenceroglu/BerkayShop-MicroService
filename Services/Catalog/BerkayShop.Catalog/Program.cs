using BerkayShop.Catalog.Extensions;
using BerkayShop.Catalog.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
{
    opt.Authority = builder.Configuration["IdentityServerURL"]; 
	opt.RequireHttpsMetadata = false;
	opt.Audience = "ResourceCatalog";
});
builder.Services.AddCatalogServices(builder.Configuration);
//"this keyword'ü sayesinde metod IServiceCollection'a 'yapışıyor' ve sınıf adı olmadan sanki IServiceCollection'ın kendi metodu gibi çağırılabiliyor. Compiler arka planda sınıf adını otomatik ekliyor."

// Add services to the container.

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

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
