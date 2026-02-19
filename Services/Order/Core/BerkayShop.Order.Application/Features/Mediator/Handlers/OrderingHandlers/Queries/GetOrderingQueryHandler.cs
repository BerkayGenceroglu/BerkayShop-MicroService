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
    public class GetOrderingQueryHandler : IRequestHandler<GetOrderingQuery, List<GetOrderingQueryResult>>
    {
        private readonly IRepository<Ordering> _repository;

        public GetOrderingQueryHandler(IRepository<Ordering> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetOrderingQueryResult>> Handle(GetOrderingQuery request, CancellationToken cancellationToken)
        {
            var orderings = await _repository.GetAllAsync();
            return orderings.Select(y => new GetOrderingQueryResult()
            {
                OrderingId = y.OrderingId,
                OrderDate = y.OrderDate,
                TotalPrice = y.TotalPrice,
                UserId = y.UserId
            }).ToList();

        }
    }
}
