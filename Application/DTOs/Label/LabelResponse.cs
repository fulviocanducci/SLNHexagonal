﻿using System;
namespace Application.DTOs.Label
{
   public class LabelResponse
   {
      public int Id { get; set; }
      public string Description { get; set; }
      public DateTime CreatedAt { get; set; }
      public DateTime UpdatedAt { get; set; }
   }
}
