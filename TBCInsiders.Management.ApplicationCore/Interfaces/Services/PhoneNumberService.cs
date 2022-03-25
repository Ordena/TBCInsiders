using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBCInsiders.Management.ApplicationCore.Exceptions;
using TBCInsiders.Management.ApplicationCore.Interfaces.Persistence;
using TBCInsiders.Management.ApplicationCore.Models.PhoneNumber;
using TBCInsiders.Management.ApplicationCore.ValidationRules.PhoneNumberValidationRule;
using TBCInsiders.Management.Domain.Entities;

namespace TBCInsiders.Management.ApplicationCore.Interfaces.Services
{
    public class PhoneNumberService : IPhoneNumberService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        public PhoneNumberService(IMapper mapper,IUnitOfWork uow)
        {
            _mapper = mapper;
            _uow = uow;
        }
        public async Task UpdateUsersPhoneNumberAsync(PhoneNumberDto phoneNumber)
        {
            var validator = new CreatePhoneNumberValidator();
            var validationResult = await validator.ValidateAsync(phoneNumber);
            if (validationResult.Errors.Count > 0)
            {
                throw new ValidationException(validationResult);
            }
            var phoneNumberToUpdate = _mapper.Map<PhoneNumber>(phoneNumber);

            await _uow.PhoneNumbers.UpdateAsync(phoneNumberToUpdate,phoneNumber.Id);
            await _uow.CommitAsync();
        }

        public async Task AddPhoneNumber(int userId, PhoneNumberDto phoneNumber)
        {
            var validator = new CreatePhoneNumberValidator();
            var validationResult = await validator.ValidateAsync(phoneNumber);
            if (validationResult.Errors.Count > 0)
            {
                throw new ValidationException(validationResult);
            }
            var phone = _mapper.Map<PhoneNumber>(phoneNumber);

            var user = await _uow.Users.GetAsync(userId);
            if (user == null)
                throw new NotFoundException(nameof(user), userId);

            user.PhoneNumbers.Add(phone);
            await _uow.CommitAsync();
        }
    }
}
