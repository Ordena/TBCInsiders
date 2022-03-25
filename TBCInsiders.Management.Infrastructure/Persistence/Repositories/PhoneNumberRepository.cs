using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBCInsiders.Management.ApplicationCore.Interfaces.Persistence;
using TBCInsiders.Management.Domain.Entities;
using TBCInsiders.Management.Infrastructure.Persistence.Data;

namespace TBCInsiders.Management.Infrastructure.Persistence.Repositories
{
    public class PhoneNumberRepository :BaseRepository<PhoneNumber>, IPhoneNumberRepository
    {
        public PhoneNumberRepository(ApplicationDbContext context) :base(context)
        {

        }

    }
}
