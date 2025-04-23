using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Domain.Interfaces.Bases
{
   public interface IGetAllAsync<T>
   {
      Task<IEnumerable<T>> GetAllAsync<Tkey>(Expression<Func<T, Tkey>> orderBy);
   }
}
