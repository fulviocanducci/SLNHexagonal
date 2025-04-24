using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Domain.Interfaces.Bases
{
   public interface IGetAsync<T, in TKey>
   {
      Task<T> GetAsync(TKey id);
      Task<T> GetAsync(Expression<Func<T, bool>> where);
   }
}
