﻿using Application.DTOs.Customer;
using Application.Interfaces;
using FluentValidation;
namespace Application.Validators.Customer
{
   public class CustomerUpdateValidator : AbstractValidator<CustomerUpdateRequest>
   {
      private readonly ICustomerService _customerService;

      public CustomerUpdateValidator(ICustomerService customerService)
      {
         _customerService = customerService;
         RuleFor(x => x.Id)
            .Configure(x => x.PropertyName = "id")
            .NotEmpty().WithMessage("Id is required.")
            .GreaterThan(0).WithMessage("Id must be greater than 0.");
         RuleFor(x => x.Name)
            .Configure(x => x.PropertyName = "name")
            .NotEmpty().WithMessage("Name is required.")
            .Length(3, 100).WithMessage("Name must be between 3 and 100 characters.");
         RuleFor(x => x.Email)
            .Configure(x => x.PropertyName = "email")
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("Email is not valid.")
            .DependentRules(() =>
            {
               RuleFor(x => x.Email)
                  .Configure(x => x.PropertyName = "email")
                  .Must((item, email) => IsEmailExistByIdOrNotExists(item.Id, email)).WithMessage("Email already exists.");
            });
         RuleFor(x => x.Status)
            .Configure(x => x.PropertyName = "status")
            .NotNull().WithMessage("Status is required.")
            .Must(x => x == true || x == false).WithMessage("Status must be true or false.");
      }

      protected bool IsEmailExistByIdOrNotExists(long id, string email)
      {
         var result = _customerService.Get(x => x.Email.Value == email);
         if (result == null)
         {
            return true;
         }
         if (result.Id == id)
         {
            return true;
         }
         return false;
      }
   }
}
