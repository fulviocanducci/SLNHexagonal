using System;
namespace Application.DTOs.Customer
{
   public class CustomerResponse
   {
      public long Id { get; set; }
      public string Name { get; set; }
      public string Email { get; set; }
      public DateTime CreatedAt { get; set; }
      public bool Status { get; set; }
   }
}