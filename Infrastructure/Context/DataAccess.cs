using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context
{
   public sealed class DataAccess : DbContext
   {
      public DataAccess(DbContextOptions<DataAccess> options) : base(options) { }
      public DbSet<Customer> Customers { get; set; }
      protected override void OnModelCreating(ModelBuilder modelBuilder)
      {
         modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataAccess).Assembly);
         base.OnModelCreating(modelBuilder);
      }
   }
}