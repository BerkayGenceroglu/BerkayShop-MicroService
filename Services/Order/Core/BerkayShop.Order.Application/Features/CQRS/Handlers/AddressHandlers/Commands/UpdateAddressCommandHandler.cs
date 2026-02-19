using BerkayShop.Order.Application.Features.CQRS.Commands.AddressCommands;
using BerkayShop.Order.Application.Interfaces;
using BerkayShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerkayShop.Order.Application.Features.CQRS.Handlers.AddressHandlers.Commands
{
    public class UpdateAddressCommandHandler
    {
        private readonly IRepository<Address> _repository;

        public UpdateAddressCommandHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateAddressCommand command)
        {
            var value = await _repository.GetByIdAsync(command.AddressId);
            value.UserId = command.UserId;
            value.District = command.District;
            value.City = command.City;
            value.Detail1 = command.Detail1;
            value.Detail2 = command.Detail2;
            value.Detail2 = command.Name;
            value.Detail2 = command.Surname;
            value.Detail2 = command.Email;
            value.Detail2 = command.Country;
            value.Detail2 = command.Phone;
            value.Detail2 = command.Description;
            value.Detail2 = command.ZipCode;
            await _repository.UpdateAsync(value);
        }
    }
}
