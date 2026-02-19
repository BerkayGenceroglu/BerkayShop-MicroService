using BerkayShop.Order.Application.Features.Mediator.Queries.OrderingQueries;
using BerkayShop.Order.Application.Features.Mediator.Results.OrderingResults;
using BerkayShop.Order.Application.Interfaces;
using BerkayShop.Order.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerkayShop.Order.Application.Features.Mediator.Handlers.OrderingHandlers.Queries
{
    public class GetOrderingByIdQueyHandler : IRequestHandler<GetOrderingByIdQuery, GetOrderingByIdQueryResult>
    {
        private readonly IRepository<Ordering> _repository;

        public GetOrderingByIdQueyHandler(IRepository<Ordering> repository)
        {
            _repository = repository;
        }

        public async Task<GetOrderingByIdQueryResult> Handle(GetOrderingByIdQuery request, CancellationToken cancellationToken)
        {
            var value =await _repository.GetByIdAsync(request.Id);
            return new GetOrderingByIdQueryResult()
            {
                OrderingId = value.OrderingId,
                UserId = value.UserId,
                TotalPrice = value.TotalPrice,
                OrderDate = value.OrderDate
            };
        }
    }
}
