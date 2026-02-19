using BerkayShop.Cargo.DataAccessLayer.Abstract;
using BerkayShop.Cargo.DataAccessLayer.Concrete;
using BerkayShop.Cargo.DataAccessLayer.Repositories;
using BerkayShop.Cargo.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerkayShop.Cargo.DataAccessLayer.EntityFramework
{
    public class EfCargoOperationDal : GenericRepository<CargoOperation>, ICargoOperationDal
    {
        public EfCargoOperationDal(CargoContext context) : base(context)
        {
        }
    }
}
