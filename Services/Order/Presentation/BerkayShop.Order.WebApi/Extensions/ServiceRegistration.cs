using BerkayShop.Order.Application.Features.CQRS.Handlers.AddressHandlers.Commands;
using BerkayShop.Order.Application.Features.CQRS.Handlers.AddressHandlers.Queries;
using BerkayShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers.Commands;
using BerkayShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers.Queries;
using BerkayShop.Order.Application.Features.Mediator.Commands.OrderingCommands;
using BerkayShop.Order.Application.Features.Mediator.Handlers.OrderingHandlers.Commands;
using BerkayShop.Order.Application.Features.Mediator.Handlers.OrderingHandlers.Queries;
using BerkayShop.Order.Application.Interfaces;
using BerkayShop.Order.Persistence.Repositories;

namespace BerkayShop.Order.WebApi.Extensions
{
    public static class ServiceRegistration
    {
        public static void AddApiServices(this IServiceCollection services)
        {

            //Adress
            services.AddScoped<CreateAddressCommandHandler>();
            services.AddScoped<UpdateAddressCommandHandler>();
            services.AddScoped<RemoveAddressCommandHandler>();
            services.AddScoped<GetAddressByIdQueryHandler>();
            services.AddScoped<GetAddressQueryHandler>();

            //OrderDetail
            services.AddScoped<CreateOrderDetailCommandHandler>();
            services.AddScoped<UpdateOrderDetailCommandHandler>();
            services.AddScoped<RemoveOrderDetailCommandHandler>();
            services.AddScoped<GetOrderDetailQueryHandler>();
            services.AddScoped<GetOrderDetailByIdQueryHandler>();

           
            //DI
            services.AddScoped<IOrderingRepository,OrderingRepository>();
        }
    }
}
