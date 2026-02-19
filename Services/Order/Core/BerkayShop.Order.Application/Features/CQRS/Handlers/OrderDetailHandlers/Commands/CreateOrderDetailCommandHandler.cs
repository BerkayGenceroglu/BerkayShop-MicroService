using BerkayShop.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using BerkayShop.Order.Application.Interfaces;
using BerkayShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerkayShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers.Commands
{
    public class CreateOrderDetailCommandHandler
    {
         private readonly IRepository<OrderDetail> _repository;

        public CreateOrderDetailCommandHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateOrderDetailCommand command)
        {
            await _repository.CreateAsync(new OrderDetail()
            {
                ProductId = command.ProductId,
                ProductName = command.ProductName,
                ProductPrice = command.ProductPrice,
                ProductAmount = command.ProductAmount,
                ProducTotalPrice = command.ProducTotalPrice,
                OrderingId = command.OrderingId
            });
        }
    }
}
