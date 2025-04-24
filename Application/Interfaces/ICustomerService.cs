using Application.DTOs.Customer;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Application.Interfaces
{
   public interface ICustomerService
   {
      Task<Customer> AddAsync(CustomerCreateRequest customer);
      Task<Customer> UpdateAsync(CustomerUpdateRequest customer);
      Task DeleteAsync(long id);
      Task<CustomerResponse> GetAsync(long id);
      Task<CustomerResponse> GetAsync(Expression<Func<Customer, bool>> where);
      Task<IEnumerable<CustomerResponse>> GetAllAsync<TKey>(Expression<Func<Customer, TKey>> orderBy);
      Task<bool> AnyAsync(Expression<Func<Customer, bool>> where);
      Task<bool> AnyAsync(long id);
   }
}
