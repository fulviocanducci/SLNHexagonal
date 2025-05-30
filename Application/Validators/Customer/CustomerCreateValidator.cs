﻿using Application.DTOs.Customer;
using Application.Interfaces;
using FluentValidation;

namespace Application.Validators.Customer
{
   public class CustomerCreateValidator : AbstractValidator<CustomerCreateRequest>
   {
      private readonly ICustomerService _customerService;

      public CustomerCreateValidator(ICustomerService customerService)
      {
         _customerService = customerService;

         RuleFor(x => x.Name)
            .Configure(x => x.PropertyName = "name")
            .NotEmpty().WithMessage("Name is required.")
            .Length(3, 100).WithMessage("Name must be between 3 and 100 characters.");

         RuleFor(x => x.Email)
            .Configure(x => x.PropertyName = "email")
            .NotEmpty().WithMessage("Date of birth is required.")
            .EmailAddress().WithMessage("Email is not valid.")
            .DependentRules(() =>
            {
               RuleFor(x => x.Email)
                  .Configure(x => x.PropertyName = "email")
                  .Must(IsEmailNotExist).WithMessage("Email already exists.");
            });

      }

      protected bool IsEmailNotExist(string email)
      {
         return _customerService.Any(x => x.Email.Value == email) == false;
      }
   }
}
