using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Context.Mappings
{
   internal class LabelMapping : IEntityTypeConfiguration<Label>
   {
      public void Configure(EntityTypeBuilder<Label> builder)
      {
         builder.ToTable("labels");

         builder.HasKey(c => c.Id);
         builder.Property(c => c.Id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd();

         builder.Property(c => c.Description)
            .HasColumnName("decription")
            .HasMaxLength(100)
            .IsRequired();

         builder.Property(c => c.CreatedAt)
            .HasColumnName("created_at")
            .IsRequired();

         builder.Property(c => c.UpdatedAt)
            .HasColumnName("updated_at")
            .IsRequired();
      }
   }
}