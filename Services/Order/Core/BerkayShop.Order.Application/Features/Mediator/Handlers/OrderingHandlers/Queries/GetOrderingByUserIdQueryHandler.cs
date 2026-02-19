using BerkayShop.Order.Application.Features.Mediator.Queries.OrderingQueries;
using BerkayShop.Order.Application.Features.Mediator.Results.OrderingResults;
using BerkayShop.Order.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerkayShop.Order.Application.Features.Mediator.Handlers.OrderingHandlers.Queries
{
    public class GetOrderingByUserIdQueryHandler : IRequestHandler<GetOrderingByUserIdQuery, List<GetOrderingByUserIdQueryResult>>
    {
        private readonly IOrderingRepository _orderingRepository;

        public GetOrderingByUserIdQueryHandler(IOrderingRepository orderingRepository)
        {
            _orderingRepository = orderingRepository;
        }

        public async Task<List<GetOrderingByUserIdQueryResult>> Handle(GetOrderingByUserIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _orderingRepository.GetOrderingByUserIdAsync(request.UserId);
            return values.Select(x => new GetOrderingByUserIdQueryResult
            {
                UserId = x.UserId,
                OrderDate = x.OrderDate,
                OrderingId = x.OrderingId,
                TotalPrice = x.TotalPrice,
            }).ToList();
        }
    }
}
