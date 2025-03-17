using FluentValidation;
namespace Application.Features.TypePurchases.Commands.CreateTypePurchaseCommand
{
    public class CreateTypePurchaseCommandValidator : AbstractValidator<CreateTypePurchaseCommand>
    {
        public CreateTypePurchaseCommandValidator()
        {
            RuleFor(c => c.PurchaseDescription).NotEmpty().WithMessage("property:{PropertyName} can't be empty");
            RuleFor(c => c.MonthDuration).NotEmpty().WithMessage("property:{PropertyName} can't be empty");
           
        }
    }
}
