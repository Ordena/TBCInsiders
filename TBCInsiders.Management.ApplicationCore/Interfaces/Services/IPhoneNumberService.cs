using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBCInsiders.Management.ApplicationCore.Models.PhoneNumber;

namespace TBCInsiders.Management.ApplicationCore.Interfaces.Services
{
    public interface IPhoneNumberService
    {
        Task UpdateUsersPhoneNumberAsync(PhoneNumberDto phoneNumber);
        Task AddPhoneNumber(int userId, PhoneNumberDto phoneNumber);
    }
}
