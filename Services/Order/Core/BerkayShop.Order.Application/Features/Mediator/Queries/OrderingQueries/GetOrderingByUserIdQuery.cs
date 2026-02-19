using BerkayShop.Order.Application.Features.Mediator.Results.OrderingResults;
using BerkayShop.Order.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerkayShop.Order.Application.Features.Mediator.Queries.OrderingQueries
{
    public class GetOrderingByUserIdQuery: IRequest<List<GetOrderingByUserIdQueryResult>>
    {
        public string UserId { get; set; }

        public GetOrderingByUserIdQuery(string userId)
        {
            UserId = userId;
        }
    }
}
