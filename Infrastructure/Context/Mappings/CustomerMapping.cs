using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Context.Mappings
{
   internal class CustomerMapping : IEntityTypeConfiguration<Customer>
   {
      public void Configure(EntityTypeBuilder<Customer> builder)
      {
         builder.ToTable("customers");

         builder.HasKey(c => c.Id);
         builder.Property(c => c.Id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd();

         builder.OwnsOne(c => c.Name, x =>
         {
            x.Property(c => c.Value)
               .HasColumnName("name")
               .IsRequired()
               .HasMaxLength(100);
         });

         builder.OwnsOne(c => c.Email, x =>
         {
            x.Property(c => c.Value)
               .HasColumnName("email")
               .IsRequired()
               .HasMaxLength(100);
         });

         builder.Property(c => c.CreatedAt)
            .HasColumnName("created_at")
            .IsRequired();

         builder.Property(c => c.Status)
            .HasColumnName("status")
            .IsRequired();
      }
   }
}