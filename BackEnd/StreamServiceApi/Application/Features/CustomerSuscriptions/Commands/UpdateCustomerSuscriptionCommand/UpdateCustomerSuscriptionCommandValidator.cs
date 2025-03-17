using FluentValidation;

namespace Application.Features.CustomerSuscriptions.Commands.UpdateCustomerSuscriptionCommand
{
    public class UpdateCustomerSuscriptionCommandValidator : AbstractValidator<UpdateCustomerSuscriptionCommand>
    {
        public UpdateCustomerSuscriptionCommandValidator()
        {
            //RuleFor(c => c.IdSuscriptionType).NotEmpty().WithMessage("property:{PropertyName} can't be empty");
            //RuleFor(c => c.IdTypePurchase).NotEmpty().WithMessage("property:{PropertyName} can't be empty");
            //RuleFor(c => c.StartDate).NotEmpty().WithMessage("property:{PropertyName} can't be empty");
            RuleFor(c => c.FinishDate).NotEmpty().WithMessage("property:{PropertyName} can't be empty");
            RuleFor(c => c.SuscriptionStatus).NotEmpty().WithMessage("property:{PropertyName} can't be empty");
        }

    }
}
