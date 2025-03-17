using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Customers.Commands.UpdateCustomerCommand
{
    public class UpdateCustomerCommandValidator: AbstractValidator<UpdateCustomerCommand>
    {
        /// <summary>
        /// reglas de validacion para actualizar Customer
        /// </summary>
        public UpdateCustomerCommandValidator()
        {
            RuleFor(c => c.Name).NotEmpty().WithMessage("property:{PropertyName} can't be empty").MaximumLength(40).WithMessage("property:{PropertyName} can't be empty larger than {MaxLength} characters");
            RuleFor(c => c.Lastnames).NotEmpty().WithMessage("property:{PropertyName} can't be empty").MaximumLength(40).WithMessage("property:{PropertyName} can't be empty larger than {MaxLength} characters");
            RuleFor(c => c.Mail).NotEmpty().WithMessage("property:{PropertyName} can't be empty").MaximumLength(30).WithMessage("property:{PropertyName} can't be empty larger than {MaxLength} characters").Matches(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$").WithMessage("property:{PropertyName} must be a valid E-mail");
            RuleFor(c => c.Password).NotNull().WithMessage("property:{PropertyName} can't be empty");
        }
    }
}
