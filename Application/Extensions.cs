using Application.Interfaces;
using Application.Mappers;
using Application.Services;
using Mapster;
using Microsoft.Extensions.DependencyInjection;
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
   }
}