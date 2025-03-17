using FluentValidation;

namespace Application.Features.SuscriptionTypes.Commands.UpdateSuscriptionTypeCommand
{
    public class UpdateSuscriptionTypeCommandValidator:AbstractValidator<UpdateSuscriptionTypeCommand>
    {
        public UpdateSuscriptionTypeCommandValidator()
        {
            RuleFor(c => c.TypeSuscription).NotEmpty().WithMessage("property:{PropertyName} can't be empty");
            RuleFor(c => c.Price).NotEmpty().WithMessage("property:{PropertyName} can't be empty");
            RuleFor(c => c.Status).NotEmpty().WithMessage("property:{PropertyName} can't be empty");
        }

    }
}
