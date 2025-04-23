using Application.DTOs.Customer;
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using Domain.ValueObjects;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Application.Services
{
   public class CustomerService : ICustomerService
   {
      private readonly ICustomerRepository _customerRepository;

      public CustomerService(ICustomerRepository customerRepository)
      {
         _customerRepository = customerRepository;
      }

      public async Task<Customer> AddAsync(CustomerCreateRequest customer)
      {
         try
         {
            Customer data = customer.Adapt<Customer>();
            await _customerRepository.AddAsync(data);
            return data;
         }
         catch (Exception ex)
         {
            var c = ex;
         }
         return null;
      }

      public Task<bool> AnyAsync(Expression<Func<Customer, bool>> where)
      {
         return _customerRepository.AnyAsync(where);
      }

      public Task<bool> AnyAsync(long id)
      {
         return _customerRepository.AnyAsync(x => x.Id == id);
      }

      public Task DeleteAsync(long id)
      {
         return _customerRepository.DeleteAsync(id);
      }

      public Task<IEnumerable<CustomerResponse>> GetAllAsync<TKey>(Expression<Func<Customer, TKey>> orderBy)
      {
         return _customerRepository.GetAllAsync(orderBy)
            .ContinueWith(task =>
            {
               IEnumerable<Customer> customers = task.Result;
               return customers.Adapt<IEnumerable<CustomerResponse>>();
            });
      }

      public Task<CustomerResponse> GetAsync(long id)
      {
         return _customerRepository.GetAsync(id)
            .ContinueWith(task =>
            {
               Customer customer = task.Result;
               return customer.Adapt<CustomerResponse>();
            });
      }

      public async Task<Customer> UpdateAsync(CustomerUpdateRequest customer)
      {
         Customer data = await _customerRepository.GetAsync(customer.Id);
         if (data == null)
         {
            return null;
         }
         data.UpdateEmail(new Email(customer.Email));
         data.UpdateName(new Name(customer.Name));
         data.UpdateStatus(customer.Status);
         await _customerRepository.UpdateAsync(data);
         return data;
      }
   }
}
