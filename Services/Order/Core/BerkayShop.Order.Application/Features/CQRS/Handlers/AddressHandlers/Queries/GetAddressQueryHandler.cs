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
    public class GetAddressQueryHandler
    {
        private readonly IRepository<Address> _repository;

        public GetAddressQueryHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }
        public async Task<List<GetAddressQueryResult>> Handle()
        {
            var values =await _repository.GetAllAsync();
            return values.Select(x => new GetAddressQueryResult
            {
                AddressId = x.AddressId,
                UserId = x.UserId,
                City = x.City,
                District = x.District,
                Detail1 = x.Detail1,
                Detail2 = x.Detail2,
                Name = x.Name,
                Surname = x.Surname,
                Phone = x.Phone,
                Email = x.Email,
                Country = x.Country,
                ZipCode = x.ZipCode,
                Description = x.Description,
            }).ToList();
        }
    }
}
