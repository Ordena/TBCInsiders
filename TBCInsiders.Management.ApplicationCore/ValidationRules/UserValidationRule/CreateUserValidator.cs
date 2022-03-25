using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TBCInsiders.Management.ApplicationCore.Extensions;
using TBCInsiders.Management.ApplicationCore.Models.PhoneNumber;
using TBCInsiders.Management.ApplicationCore.Models.User;
using TBCInsiders.Management.ApplicationCore.ValidationRules.PhoneNumberValidationRule;

namespace TBCInsiders.Management.ApplicationCore.ValidationRules.UserValidationRule
{
    public class CreateUserValidator : AbstractValidator<CreateUserDto>
    {
        //TODO: ADD CUSTOM Culture-specific VALIDATION RULE

        public CreateUserValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().NotNull().WithMessage("FirstName is required.").MinimumLength(2).MaximumLength(50).Must(ValidateCulture).WithMessage("UserName must be only in georgian or latin language."); 
            RuleFor(x => x.LastName).NotEmpty().NotNull().WithMessage("FirstName is required.").MinimumLength(2).MaximumLength(50).Must(ValidateCulture).WithMessage("UserName must be only in georgian or latin language.");
            RuleFor(x => x.PersonalNumber).NotNull().NotEmpty().WithMessage("PersonalNumber is required.").Length(11, 11);
            RuleFor(x => x.DateOfBirth).NotEmpty().NotNull().WithMessage("Birth date is Required.").LessThanOrEqualTo(DateTime.Now.AddYears(-18)).WithMessage("Age must be greater 18.");
            RuleForEach(x => x.PhoneNumbers).SetValidator(new CreatePhoneNumberValidator());
            
        }
        private bool PhoneNumberSpecification(List<PhoneNumberDto> phoneNumbers)
        {
            return phoneNumbers.Any(x => x.Phone.Length < 4 || x.Phone.Length > 50 || string.IsNullOrEmpty(x.Phone));
        }

        private bool ValidateCulture(string value)
        {
            return (StringExtensions.IsGeorgian(value) || StringExtensions.IsLatin(value));
        }



    }
}
