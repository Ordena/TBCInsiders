using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBCInsiders.Management.Domain.Entities;

namespace TBCInsiders.Management.ApplicationCore.Interfaces.Persistence
{
    public interface IPhoneNumberRepository : IRepositoryBase<PhoneNumber>
    {
        //Task UpdateUsersPhoneNumber(PhoneNumber phoneNumber);
        //Task AddPhoneNumber(int userId, PhoneNumber phoneNumber);
    }
}
