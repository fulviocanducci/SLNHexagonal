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

      public bool Any(Expression<Func<Customer, bool>> where)
      {
         return _customerRepository.Any(where);
      }

      public bool Any(long id)
      {
         return _customerRepository.Any(x => x.Id == id);
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

      public CustomerResponse Get(long id)
      {
         var data = _customerRepository.Get(id);
         if (data == null)
         {
            return null;
         }
         return data.Adapt<CustomerResponse>();
      }

      public CustomerResponse Get(Expression<Func<Customer, bool>> where)
      {
         var data = _customerRepository.Get(where);
         if (data == null)
         {
            return null;
         }
         return data.Adapt<CustomerResponse>();
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

      public Task<CustomerResponse> GetAsync(Expression<Func<Customer, bool>> where)
      {
         return _customerRepository.GetAsync(where)
            .ContinueWith(task =>
            {
               Customer customer = task.Result;
               return customer.Adapt<CustomerResponse>();
            });
      }

      public async Task<Customer> UpdateAsync(CustomerUpdateRequest customer)
      {
         Customer data = await _customerRepository.FindAsync(customer.Id);
         if (data == null)
         {
            return null;
         }
         data.UpdateEmail(new Email(customer.Email));
         data.UpdateName(new Name(customer.Name));
         data.UpdateStatus(customer.Status);
         return data;
      }
   }
}