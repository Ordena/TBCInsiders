using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBCInsiders.Management.ApplicationCore.Models.PhoneNumber;

namespace TBCInsiders.Management.ApplicationCore.ValidationRules.PhoneNumberValidationRule
{
    public class CreatePhoneNumberValidator : AbstractValidator<PhoneNumberDto>
    {
        public CreatePhoneNumberValidator()
        {
            RuleFor(x => x.Phone).NotNull().NotEmpty().WithMessage("Phone Number is required.").Length(4, 50).WithMessage("Phone Number must contain specified number of digits(4-50).");
            RuleFor(x => x.TypeId).NotNull().NotEmpty().WithMessage("Phone Type is required.");
        }
    }
}
