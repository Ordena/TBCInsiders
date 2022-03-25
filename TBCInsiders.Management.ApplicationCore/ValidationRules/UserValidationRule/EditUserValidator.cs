using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBCInsiders.Management.ApplicationCore.Models.User;
using TBCInsiders.Management.ApplicationCore.ValidationRules.PhoneNumberValidationRule;

namespace TBCInsiders.Management.ApplicationCore.ValidationRules.UserValidationRule
{
    public class EditUserValidator : AbstractValidator<EditUserDto>
    {
        public EditUserValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().NotNull().WithMessage("FirstName is required.").MinimumLength(2).MaximumLength(50);
            RuleFor(x => x.LastName).NotEmpty().NotNull().WithMessage("FirstName is required.").MinimumLength(2).MaximumLength(50);
            RuleFor(x => x.PersonalNumber).NotNull().NotEmpty().WithMessage("PersonalNumber is required.").Length(11, 11);
            RuleFor(x => x.DateOfBirth).NotEmpty().NotNull().WithMessage("Birth date is Required.").LessThanOrEqualTo(DateTime.Now.AddYears(-18)).WithMessage("Age must be greater 18.");

        }
        
    }
}
