using BerkayShop.Cargo.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerkayShop.Cargo.BusinessLayer.Abstract
{
    public interface ICargoCustomerService:IGenericService<CargoCustomer>
    {
        Task<CargoCustomer> TGetCargoCustomerByUserId(string userId);

    }
}
