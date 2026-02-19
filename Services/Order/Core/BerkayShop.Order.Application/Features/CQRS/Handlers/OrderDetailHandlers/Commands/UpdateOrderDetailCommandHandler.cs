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
    public class UpdateOrderDetailCommandHandler
    {
        private readonly IRepository<OrderDetail> _repository;

        public UpdateOrderDetailCommandHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateOrderDetailCommand command)
        {
            var value = await _repository.GetByIdAsync(command.OrdertDetailId);
            value.ProductName = command.ProductName;
            value.ProductId = command.ProductId;
            value.ProductPrice = command.ProductPrice;
            value.ProductAmount = command.ProductAmount;
            value.ProducTotalPrice = command.ProducTotalPrice;
            value.OrderingId = command.OrderingId;
            await _repository.UpdateAsync(value);
        }
    }
}
