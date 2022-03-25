using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBCInsiders.Management.ApplicationCore.Interfaces.Persistence;
using TBCInsiders.Management.Infrastructure.Persistence.Data;

namespace TBCInsiders.Management.Infrastructure.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Users = new UserRepository(_context);
            ConnectedUsers = new ConnectedUserRepository(_context);
            UserConnections = new UserConnectionsRepository(_context);
            PhoneNumbers = new PhoneNumberRepository(_context);
        }
        public IUserRepository Users { get; private set; }
        public IConnectedUserRepository ConnectedUsers { get; private set; }
        public IUserConnectionsRepository UserConnections { get; private set; }
        public IPhoneNumberRepository PhoneNumbers { get; private set; }
        public int Commit()
        {
            return _context.SaveChanges();
        }

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
