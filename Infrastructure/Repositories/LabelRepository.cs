using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repositories
{
   public sealed class LabelRepository: ILabelRepository
   {
      private readonly DataAccess _dataAccess;

      public LabelRepository(DataAccess dataAccess)
      {
         _dataAccess = dataAccess;
      }
      public Task AddAsync(Label value)
      {
         _dataAccess.Labels.AddAsync(value);
         return Task.CompletedTask;
      }
      public bool Any(Expression<Func<Label, bool>> where)
      {
         return _dataAccess.Labels.Any(where);
      }
      public Task<bool> AnyAsync(Expression<Func<Label, bool>> where)
      {
         return _dataAccess.Labels.AnyAsync(where);
      }
      public async Task DeleteAsync(long id)
      {
         Label label = await GetAsync(id);
         if (label == null)
         {
            ArgumentNullException argumentNullException = new(nameof(label));
            throw argumentNullException;
         }
         _dataAccess.Labels.Remove(label);
      }
      public Task DeleteAsync(Label model)
      {
         _dataAccess.Labels.Remove(model);
         return Task.CompletedTask;
      }
      public async Task<Label> FindAsync(params object[] keyValues)
      {
         return await _dataAccess.Labels.FindAsync(keyValues);
      }
      public Task<Label> FindAsync(Expression<Func<Label, bool>> where)
      {
         return _dataAccess.Labels.Where(where).FirstOrDefaultAsync();
      }
      public Label Get(long id)
      {
         return Get(x => x.Id == id);
      }
      public Label Get(Expression<Func<Label, bool>> where)
      {
         return _dataAccess
            .Labels
            .AsNoTracking()
            .Where(where)
            .FirstOrDefault();
      }
      public async Task<IEnumerable<Label>> GetAllAsync<Tkey>(Expression<Func<Label, Tkey>> orderBy)
      {
         return await _dataAccess
            .Labels
            .AsNoTracking()
            .OrderBy(orderBy)
            .ToListAsync();
      }
      public async Task<Label> GetAsync(long id)
      {
         return await _dataAccess
            .Labels
            .AsNoTracking()
            .Where(x => x.Id == id)
            .FirstOrDefaultAsync();
      }
      public Task<Label> GetAsync(Expression<Func<Label, bool>> where)
      {
         return _dataAccess
            .Labels
            .AsNoTracking()
            .Where(where)
            .FirstOrDefaultAsync();
      }
      public Task UpdateAsync(Label value)
      {
         _dataAccess.Entry(value).State = EntityState.Modified;
         _dataAccess.Labels.Update(value);
         return Task.CompletedTask;
      }
   }
}
