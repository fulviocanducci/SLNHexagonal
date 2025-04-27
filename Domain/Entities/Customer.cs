using Domain.ValueObjects;
using System;
namespace Domain.Entities
{
   public class Customer
   {
      public long Id { get; private set; }
      public Name Name { get; private set; }
      public Email Email { get; private set; }
      public DateTime CreatedAt { get; private set; }
      public bool Status { get; private set; }
      private void UpdateAll(long id, Name name, Email email, DateTime createdAt, bool status)
      {
         Id = id;
         Name = name ?? throw new ArgumentNullException(nameof(name));
         Email = email ?? throw new ArgumentNullException(nameof(email));
         CreatedAt = createdAt;
         Status = status;
      }

      protected Customer() { }      

      public Customer(long id, Name name, Email email)
      {
         UpdateAll(id, name, email, DateTime.UtcNow, true);
      }

      public Customer(long id, Name name, Email email, bool status)
      {
         UpdateAll(id, name, email, DateTime.UtcNow, status);         
      }

      public Customer(Name name, Email email)
      {
         UpdateAll(0, name, email, DateTime.UtcNow, true);
      }

      public Customer(Name name, Email email, bool status)
      {
         UpdateAll(0, name, email, DateTime.UtcNow, status);
      }

      public Customer Activate()
      {
         Status = true;
         return this;
      }

      public Customer Toggle()
      {
         Status = !Status;
         return this;
      }

      public Customer Deactivate()
      {
         Status = false;
         return this;
      }

      public Customer UpdateStatus(bool status)
      {
         Status = status;
         return this;
      }

      public Customer UpdateName(Name newName)
      {
         Name = newName ?? throw new ArgumentNullException(nameof(newName));
         return this;
      }

      public Customer UpdateEmail(Email newEmail)
      {
         Email = newEmail ?? throw new ArgumentNullException(nameof(newEmail));
         return this;
      }

      public Customer UpdateCreatedAt(DateTime createdAt)
      {
         CreatedAt = createdAt;
         return this;
      }
   }
}
