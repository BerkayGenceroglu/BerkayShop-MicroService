using BerkayShop.Order.Application.Features.CQRS.Queries.AdressQueries;
using BerkayShop.Order.Application.Features.CQRS.Results.AddressResults;
using BerkayShop.Order.Application.Interfaces;
using BerkayShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerkayShop.Order.Application.Features.CQRS.Handlers.AddressHandlers.Queries
{
    public class GetAddressByIdQueryHandler
    {
        private readonly IRepository<Address> _repository;

        public GetAddressByIdQueryHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }
        public async Task<GetAddresByIdQueryResult> Handle(GetAddressByIdQuery query)
        {
            var value = await _repository.GetByIdAsync(query.Id);
            return new GetAddresByIdQueryResult
            {
                AddressId = value.AddressId,
                UserId = value.UserId,
                City = value.City,
                District = value.District,
                Detail1 = value.Detail1,
                Detail2 = value.Detail2,
                Country = value.Country,
                Description = value.Description,
                Name = value.Name,
                Surname = value.Surname,
                Email = value.Email,
                Phone = value.Phone,
                ZipCode = value.ZipCode,
            };
        }
    }
}
