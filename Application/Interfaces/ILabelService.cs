using Application.DTOs.Label;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Application.Interfaces
{
   public interface ILabelService
   {
      Task<Label> AddAsync(LabelCreateRequest customer);
      Task<Label> UpdateAsync(LabelUpdateRequest customer);
      Task DeleteAsync(long id);
      Task<LabelResponse> GetAsync(long id);
      Task<LabelResponse> GetAsync(Expression<Func<Label, bool>> where);
      LabelResponse Get(long id);
      LabelResponse Get(Expression<Func<Label, bool>> where);
      Task<IEnumerable<LabelResponse>> GetAllAsync<TKey>(Expression<Func<Label, TKey>> orderBy);
      Task<bool> AnyAsync(Expression<Func<Label, bool>> where);
      bool Any(Expression<Func<Label, bool>> where);
      Task<bool> AnyAsync(long id);
      bool Any(long id);
   }
}
