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

      protected Customer() { }

      public Customer(long id, Name name, Email email)
      {
         Id = id;
         Name = name ?? throw new ArgumentNullException(nameof(name));
         Email = email ?? throw new ArgumentNullException(nameof(email));
         CreatedAt = DateTime.UtcNow;
         Status = true;
      }

      public Customer(long id, Name name, Email email, bool status)
      {
         Id = id;
         Name = name ?? throw new ArgumentNullException(nameof(name));
         Email = email ?? throw new ArgumentNullException(nameof(email));
         CreatedAt = DateTime.UtcNow;
         Status = status;
      }

      public Customer(Name name, Email email)
      {
         Name = name ?? throw new ArgumentNullException(nameof(name));
         Email = email ?? throw new ArgumentNullException(nameof(email));
         CreatedAt = DateTime.UtcNow;
         Status = true;
      }

      public Customer(Name name, Email email, bool status)
      {
         Name = name ?? throw new ArgumentNullException(nameof(name));
         Email = email ?? throw new ArgumentNullException(nameof(email));
         CreatedAt = DateTime.UtcNow;
         Status = status;
      }

      public Customer Activate()
      {
         Status = true;
         return this;
      }

      public Customer Toggle()
      {
         Status = Status == true
            ? false
            : true;
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
