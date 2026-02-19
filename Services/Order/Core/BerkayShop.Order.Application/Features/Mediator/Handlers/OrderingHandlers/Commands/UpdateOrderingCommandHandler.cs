using BerkayShop.Order.Application.Features.Mediator.Commands.OrderingCommands;
using BerkayShop.Order.Application.Interfaces;
using BerkayShop.Order.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerkayShop.Order.Application.Features.Mediator.Handlers.OrderingHandlers.Commands
{
    public class UpdateOrderingCommandHandler : IRequestHandler<UpdateOrderingCommand>
    {
        private readonly IRepository<Ordering> _repository;

        public UpdateOrderingCommandHandler(IRepository<Ordering> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateOrderingCommand request, CancellationToken cancellationToken)
        {
            var value =await _repository.GetByIdAsync(request.OrderingId);
            value.OrderDate = DateTime.Now;
            value.TotalPrice = request.TotalPrice;  
            value.UserId = request.UserId;
            await _repository.UpdateAsync(value);
        }
    }
}
