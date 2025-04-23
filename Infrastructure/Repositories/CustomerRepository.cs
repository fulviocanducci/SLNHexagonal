using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repositories
{
   internal class CustomerRepository : ICustomerRepository
   {
      private readonly DataAccess _dataAccess;

      public CustomerRepository(DataAccess dataAccess)
      {
         _dataAccess = dataAccess;
      }

      public Task AddAsync(Customer value)
      {
         _dataAccess.Customers.AddAsync(value);
         return Task.CompletedTask;
      }

      public Task<bool> AnyAsync(Expression<Func<Customer, bool>> where)
      {
         return _dataAccess.Customers.AnyAsync(where);
      }

      public async Task DeleteAsync(long id)
      {
         Customer customer = await GetAsync(id);
         if (customer == null)
         {
            ArgumentNullException argumentNullException = new(nameof(customer));
            throw argumentNullException;
         }

         _dataAccess.Customers.Remove(customer);
      }

      public Task DeleteAsync(Customer model)
      {
         _dataAccess.Customers.Remove(model);
         return Task.CompletedTask;
      }

      public async Task<IEnumerable<Customer>> GetAllAsync<Tkey>(Expression<Func<Customer, Tkey>> orderBy)
      {
         return await _dataAccess
            .Customers
            .AsNoTracking()
            .OrderBy(orderBy)
            .ToListAsync();
      }

      public async Task<Customer> GetAsync(long id)
      {
         return await _dataAccess
            .Customers
            .AsNoTracking()
            .Where(x => x.Id == id)
            .FirstOrDefaultAsync();
      }

      public Task UpdateAsync(Customer value)
      {
         return Task.Run(() =>
         {
            _dataAccess.Entry(value).State = EntityState.Modified;
            _dataAccess.Update(value);
         });
      }
   }
}
