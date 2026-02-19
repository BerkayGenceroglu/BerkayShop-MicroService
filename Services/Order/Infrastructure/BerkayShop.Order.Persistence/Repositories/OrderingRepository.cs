using BerkayShop.Order.Application.Interfaces;
using BerkayShop.Order.Domain.Entities;
using BerkayShop.Order.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerkayShop.Order.Persistence.Repositories
{
    public class OrderingRepository : IOrderingRepository
    {
        private readonly OrderContext _context;

        public OrderingRepository(OrderContext context)
        {
            _context = context;
        }

        public async Task<DateTime> GetLastOrderDate()
        {
            var lastOrderDate = await _context.Orderings.OrderByDescending(x => x.OrderDate).Select(x => x.OrderDate.ToString()).FirstOrDefaultAsync();
            return DateTime.Parse(lastOrderDate)!;
        }

        public async Task<List<Ordering>> GetOrderingByUserIdAsync(string userId)
        {
            var values = await _context.Orderings.Where(x => x.UserId == userId).ToListAsync();
            return values;
        }

        public async Task<decimal> GetTotalOrderPriceCount()
        {
            var SumTotalOrderPrice = await _context.Orderings.SumAsync(x => x.TotalPrice);
            return SumTotalOrderPrice;
        }
    }
}
