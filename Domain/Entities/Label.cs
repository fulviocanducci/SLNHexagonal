using System;
namespace Domain.Entities
{
   public class Label
   {
      protected Label() { }
      public Label(string description)
      {
         Description = description ?? throw new ArgumentNullException(nameof(description));
         CreatedAt = DateTime.UtcNow;
         UpdatedAt = DateTime.UtcNow;
      }
      public Label(int id, string description)
      {
         Id = id;
         Description = description ?? throw new ArgumentNullException(nameof(description));
         CreatedAt = DateTime.UtcNow;
         UpdatedAt = DateTime.UtcNow;
      }
      public Label(int id, string description, DateTime createdAt, DateTime updatedAt)
      {
         Id = id;
         Description = description ?? throw new ArgumentNullException(nameof(description));
         CreatedAt = createdAt;
         UpdatedAt = updatedAt;
      }
      public int Id { get; private set; }
      public string Description { get; private set; }
      public DateTime CreatedAt { get; private set; }
      public DateTime UpdatedAt { get; private set; }

      public void UpdateDescription(string description)
      {
         Description = description ?? throw new ArgumentNullException(nameof(description));
         UpdatedAt = DateTime.UtcNow;
      }
      public void UpdateCreatedAt(DateTime createdAt)
      {
         CreatedAt = createdAt;
      }
      public void UpdateUpdatedAt(DateTime updatedAt)
      {
         UpdatedAt = updatedAt;
      }
      public void UpdateLabel(string description, DateTime createdAt, DateTime updatedAt)
      {
         Description = description ?? throw new ArgumentNullException(nameof(description));
         CreatedAt = createdAt;
         UpdatedAt = updatedAt;
      }
   }
}
