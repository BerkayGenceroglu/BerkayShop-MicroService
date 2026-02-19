using BerkayShop.Order.Application.Features.CQRS.Results.OrderDetailResults;
using BerkayShop.Order.Application.Interfaces;
using BerkayShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerkayShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers.Queries
{
    public class GetOrderDetailQueryHandler 
    {
        private readonly IRepository<OrderDetail> _repository;

        public GetOrderDetailQueryHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }
        public async Task<List<GetOrderDetailQueryResult>> Handle()
        {
            var values = await _repository.GetAllAsync();
            return values.Select(y => new GetOrderDetailQueryResult
            {
                OrdertDetailId = y.OrderDetailId,
                OrderingId = y.OrderingId,
                ProductAmount = y.ProductAmount,
                ProductId = y.ProductId,
                ProductPrice = y.ProductPrice,
                ProducTotalPrice = y.ProducTotalPrice,
                ProductName = y.ProductName
            }).ToList();
        }
    }
}
