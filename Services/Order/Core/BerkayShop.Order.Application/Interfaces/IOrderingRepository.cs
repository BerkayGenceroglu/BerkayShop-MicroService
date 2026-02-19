using BerkayShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerkayShop.Order.Application.Interfaces
{
    public interface IOrderingRepository
    {
        Task<List<Ordering>>  GetOrderingByUserIdAsync(string userId);
        Task<decimal> GetTotalOrderPriceCount();
        Task<DateTime> GetLastOrderDate();
    }
}
