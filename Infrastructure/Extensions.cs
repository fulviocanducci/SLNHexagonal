using Domain.Interfaces;
using Infrastructure.Context;
using Infrastructure.Interfaces;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
   public static class Extensions
   {
      public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
      {
         services.AddDbContext<DataAccess>(options =>
         {
            options.UseMySql
            (
               configuration.GetConnectionString("DefaultConnection"),
               new MySqlServerVersion(new Version(8, 0, 42)),
               options => { }
            );
         });
         services.AddScoped<IUnitOfWork, UnitOfWork>();
         services.AddScoped<ICustomerRepository, CustomerRepository>();
         return services;
      }
   }
}
