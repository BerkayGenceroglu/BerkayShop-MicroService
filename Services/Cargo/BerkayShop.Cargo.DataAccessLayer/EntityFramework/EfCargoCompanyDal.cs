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
    public class EfCargoCompanyDal : GenericRepository<CargoCompany>, ICargoCompanyDal
    {
        private readonly CargoContext _context;
        public EfCargoCompanyDal(CargoContext context) : base(context)
        {
            _context = context;
        }

        public async Task<int> GetTotalCargoCompanyCount()
        {
            var count = await _context.CargoCompanies.CountAsync();
            return count;
        }
    }
}
