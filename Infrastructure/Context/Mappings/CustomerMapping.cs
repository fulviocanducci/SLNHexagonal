using Domain.Entities;
using Domain.ValueObjects;
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

         builder.Property(c => c.Name)
            .HasColumnName("name")
            .IsRequired()
            .HasMaxLength(100)
            .HasConversion
            (
               db => db.Value, 
               value => new Name(value)
            );
         
         builder.Property(c => c.Email)
            .HasColumnName("email")
            .IsRequired()
            .HasMaxLength(100)
            .HasConversion
            (
               db => db.Value,
               value => new Email(value)
            );
         
         builder.Property(c => c.CreatedAt)
            .HasColumnName("created_at")
            .IsRequired();
         
         builder.Property(c => c.Status)
            .HasColumnName("status")
            .IsRequired();
      }
   }
}