using System;
using System.Linq.Expressions;

namespace Domain.Interfaces.Bases
{
   public interface IAny<T>
   {
      bool Any(Expression<Func<T, bool>> where);      
   }
}
