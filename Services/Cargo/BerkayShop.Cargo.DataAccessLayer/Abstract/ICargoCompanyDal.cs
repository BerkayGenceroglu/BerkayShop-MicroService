using BerkayShop.Cargo.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerkayShop.Cargo.DataAccessLayer.Abstract
{
    public interface ICargoCompanyDal:IGenericDal<CargoCompany>
    {
        Task<int> GetTotalCargoCompanyCount();
    }
}
