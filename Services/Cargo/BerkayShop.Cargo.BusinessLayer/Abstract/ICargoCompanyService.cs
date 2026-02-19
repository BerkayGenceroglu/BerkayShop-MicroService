using BerkayShop.Cargo.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerkayShop.Cargo.BusinessLayer.Abstract
{
    public interface ICargoCompanyService:IGenericService<CargoCompany>
    {
        Task<int> TGetTotalCargoCompanyCount();
    }
}
