using Application.DTOs.Label;
using FluentValidation;

namespace Application.Validators.Label
{
   public class LabelUpdateValidator : AbstractValidator<LabelUpdateRequest>
   {
      public LabelUpdateValidator()
      {
         RuleFor(x => x.Id)
            .Configure(x => x.PropertyName = "id")
            .NotEmpty().WithMessage("Descripton is required.");

         RuleFor(x => x.Description)
            .Configure(x => x.PropertyName = "description")
            .NotEmpty().WithMessage("Descripton is required.")
            .Length(3, 100).WithMessage("Description must be between 3 and 100 characters.");
      }
   }
}
