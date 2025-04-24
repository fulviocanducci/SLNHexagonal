using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Domain.Interfaces.Bases
{
   public interface IFindAsync<T, in TKey>
   {
      Task<T> FindAsync(params object[] keyValues);
      Task<T> FindAsync(Expression<Func<T, bool>> where);
   }
}
