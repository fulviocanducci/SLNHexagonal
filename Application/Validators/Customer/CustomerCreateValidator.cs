using Application.DTOs.Customer;
using Application.Interfaces;
using FluentValidation;
using System.Threading;
using System.Threading.Tasks;

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
            .Must(IsEmailNotExist).WithMessage("Email already exists.");
      }

      protected bool IsEmailNotExist(string email)
      {
         return _customerService
            .AnyAsync(x => x.Email.Value.Contains(email))
            .Result == false;
      }
   }
}
