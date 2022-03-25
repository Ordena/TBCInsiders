using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBCInsiders.Management.ApplicationCore.Interfaces.Persistence
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; }
        IConnectedUserRepository ConnectedUsers { get; }
        IUserConnectionsRepository UserConnections { get; }
        IPhoneNumberRepository PhoneNumbers{ get; }
        int Commit();
        Task<int> CommitAsync();
    }
}
