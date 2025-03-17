using FluentValidation;
namespace Application.Features.Customers.Commands.CreateCustomerCommand
{
    public class CreateCustomerCommandValidator: AbstractValidator<CreateCustomerCommand>
    {
        /// <summary>
        /// reglas de validadacion
        /// </summary>
        public CreateCustomerCommandValidator()
        {
            RuleFor(c => c.IdenticacionCode).MaximumLength(15).WithMessage("property:{PropertyName} can't be empty larger than {MaxLength} characters");
            RuleFor(c => c.Name).NotEmpty().WithMessage("property:{PropertyName} can't be empty").MaximumLength(40).WithMessage("property:{PropertyName} can't be empty larger than {MaxLength} characters");
            RuleFor(c => c.Lastnames).NotEmpty().WithMessage("property:{PropertyName} can't be empty").MaximumLength(40).WithMessage("property:{PropertyName} can't be empty larger than {MaxLength} characters");
            RuleFor(c => c.Mail).NotEmpty().WithMessage("property:{PropertyName} can't be empty").MaximumLength(30).WithMessage("property:{PropertyName} can't be empty larger than {MaxLength} characters").Matches(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$").WithMessage("property:{PropertyName} must be a valid E-mail");
            RuleFor(c => c.Password).NotNull().WithMessage("property:{PropertyName} can't be empty");
          
        }
    }
}
