using BerkayShop.Cargo.DataAccessLayer.Abstract;
using BerkayShop.Cargo.DataAccessLayer.Concrete;
using BerkayShop.Cargo.DataAccessLayer.Repositories;
using BerkayShop.Cargo.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerkayShop.Cargo.DataAccessLayer.EntityFramework
{
    public class EfCargoCustomerDal : GenericRepository<CargoCustomer>, ICargoCustomerDal
    {
        private readonly CargoContext _context;
        public EfCargoCustomerDal(CargoContext context) : base(context)
        {
            _context = context;
        }

        public async Task<CargoCustomer> GetCargoCustomerByUserId(string userId)
        {
            var values = await _context.CargoCustomers.Where(x => x.UserCustomerId == userId).FirstOrDefaultAsync();
            return values!;
        }
    }
}
