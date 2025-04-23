using System;

namespace Application.DTOs.Customer
{
   public class CustomerUpdateRequest: CustomerCreateRequest
   {
      public long Id { get; set; }      
      public bool Status { get; set; }
   }
}