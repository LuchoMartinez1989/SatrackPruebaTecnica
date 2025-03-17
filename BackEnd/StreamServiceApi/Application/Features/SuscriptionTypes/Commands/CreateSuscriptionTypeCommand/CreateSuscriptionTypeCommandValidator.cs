using FluentValidation;
namespace Application.Features.SuscriptionTypes.Commands.CreateSuscriptionTypeCommand
{
    public class CreateSuscriptionTypeCommandValidator: AbstractValidator<CreateSuscriptionTypeCommand>
    {
        public CreateSuscriptionTypeCommandValidator()
        {
            RuleFor(c => c.TypeSuscription).NotNull().WithMessage("property:{PropertyName} can't be empty");
            RuleFor(c => c.Price).NotNull().WithMessage("property:{PropertyName} can't be empty");
            RuleFor(c => c.Status).NotNull().WithMessage("property:{PropertyName} can't be empty");
        }
    }
}
