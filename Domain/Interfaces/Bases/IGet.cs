using System;
using System.Linq.Expressions;

namespace Domain.Interfaces.Bases
{
   public interface IGet<T, in TKey>
   {
      T Get(TKey id);
      T Get(Expression<Func<T, bool>> where);
   }
}
