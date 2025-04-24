using Application.DTOs.Label;
using FluentValidation;

namespace Application.Validators.Label
{
   public class LabelCreateValidator : AbstractValidator<LabelCreateRequest>
   {
      public LabelCreateValidator()
      {
         RuleFor(x => x.Description)
            .Configure(x => x.PropertyName = "description")
            .NotEmpty().WithMessage("Descripton is required.")
            .Length(3, 100).WithMessage("Description must be between 3 and 100 characters.");
      }
   }
}
