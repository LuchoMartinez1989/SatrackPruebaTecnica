using FluentValidation;

namespace Application.Features.CustomerSuscriptions.Commands.CreateCustomerSuscriptionCommand
{
    public class CreateCustomerSuscriptionCommandValidator : AbstractValidator<CreateCustomerSuscriptionCommand>
    {
        /// <summary>
        /// reglas de validadacion
        /// </summary>
        public CreateCustomerSuscriptionCommandValidator()
        {
            
            RuleFor(c => c.SuscriptionTypeId).NotNull().WithMessage("property:{PropertyName} can't be empty");
            RuleFor(c => c.TypePurchaseId).NotNull().WithMessage("property:{PropertyName} can't be empty");
            RuleFor(c => c.StartDate).NotNull().WithMessage("property:{PropertyName} can't be empty");
            //RuleFor(c => c.FinishDate).NotNull().WithMessage("property:{PropertyName} can't be empty");
            //RuleFor(c => c.SuscriptionStatus).NotNull().WithMessage("property:{PropertyName} can't be empty");
        }
    }
}
