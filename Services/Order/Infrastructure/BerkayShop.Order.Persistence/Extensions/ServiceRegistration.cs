using BerkayShop.Order.Application.Interfaces;
using BerkayShop.Order.Persistence.Context;
using BerkayShop.Order.Persistence.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerkayShop.Order.Persistence.Extensions
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            // DbContext
            services.AddDbContext<OrderContext>();

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            // “IRepository<T> hangi T ile çağrılırsa, aynı T ile Repository<T> oluştur ve onu ver.”

        }
    }
}
