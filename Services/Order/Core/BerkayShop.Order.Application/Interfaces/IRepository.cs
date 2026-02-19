using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BerkayShop.Order.Application.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task CreateAsync(T Entity);
        Task UpdateAsync(T Entity);
        Task RemoveAsync(T Entity);
        Task<T> GetByFilterAsync(Expression<Func<T, bool>> filter);
        // Expression = Linq içindeki sorguyu tutan ve generic kullanılabilir hale getiren yapı! 
    }
}
