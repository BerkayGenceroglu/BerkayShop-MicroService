using BerkayShop.Order.Application.Features.CQRS.Queries.OrderDetailQueries;
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
    public class GetOrderDetailByIdQueryHandler
    {
        private readonly IRepository<OrderDetail> _repository;

        public GetOrderDetailByIdQueryHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }
        public async Task<GetOrderDetailByIdQueryResult> Handle(GetOrderDetailByIdQuery query)
        {
            var value = await _repository.GetByIdAsync(query.OrderDetailId);
            return new GetOrderDetailByIdQueryResult
            {
                OrdertDetailId = value.OrderDetailId,
                OrderingId = value.OrderingId,
                ProductAmount = value.ProductAmount,
                ProductId = value.ProductId,
                ProductPrice = value.ProductPrice,
                ProducTotalPrice = value.ProducTotalPrice,
                ProductName = value.ProductName
            };
        }
    }
}
