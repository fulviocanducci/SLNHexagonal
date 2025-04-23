using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Domain.Interfaces.Bases
{
   public interface IAnyAsync<T>
   {
      Task<bool> AnyAsync(Expression<Func<T, bool>> where);
   }
}
