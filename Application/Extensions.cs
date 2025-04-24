using Application.Interfaces;
using Application.Mappers;
using Application.Services;
using FluentValidation.AspNetCore;
using FluentValidation;
using Mapster;
using Microsoft.Extensions.DependencyInjection;
using Application.Validators.Customer;
namespace Application
{
   public static class Extensions
   {
      public static IServiceCollection AddApplication(this IServiceCollection services)
      {
         TypeAdapterConfig.GlobalSettings.Scan(typeof(CustomerMapper).Assembly);         
         services.AddMapster();
         services.AddScoped<ICustomerService, CustomerService>();
         return services;
      }
      public static IServiceCollection AddFluentValidation(this IServiceCollection services)
      {
         services.AddFluentValidationAutoValidation();
         services.AddValidatorsFromAssemblyContaining<CustomerCreateValidator>();
         return services;
      }
   }
}