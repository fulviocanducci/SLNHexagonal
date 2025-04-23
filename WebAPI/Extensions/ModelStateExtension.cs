using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace WebAPI.Extensions
{
   public static class ModelStateExtension
   {
      public static bool IsProblem(this ModelStateDictionary modelState)
      {
         return modelState.IsValid == false;
      }
   }
}