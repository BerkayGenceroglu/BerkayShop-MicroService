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
    public class CreateAddressCommandHandler
    {
        private readonly IRepository<Address> _repository;

        public CreateAddressCommandHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateAddressCommand command)
        {
            await _repository.CreateAsync(new Address
            {
                Name = command.Name,
                Surname = command.Surname,
                Email = command.Email,
                Phone = command.Phone,
                Country = command.Country,
                City = command.City,
                District = command.District,
                UserId = command.UserId,
                Detail1 = command.Detail1,
                Detail2 = command.Detail2,
                Description = command.Description,
                ZipCode = command.ZipCode,
            });
        }

    }
}
