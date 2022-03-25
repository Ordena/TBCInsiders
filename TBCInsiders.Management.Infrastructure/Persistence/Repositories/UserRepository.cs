using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBCInsiders.Management.ApplicationCore.Interfaces.Persistence;
using TBCInsiders.Management.ApplicationCore.Models.ConnectedUser;
using TBCInsiders.Management.ApplicationCore.Models.Filters;
using TBCInsiders.Management.ApplicationCore.Models.User;
using TBCInsiders.Management.Domain.Entities;
using TBCInsiders.Management.Infrastructure.Common;
using TBCInsiders.Management.Infrastructure.Persistence.Data;

namespace TBCInsiders.Management.Infrastructure.Persistence.Repositories
{
    public class UserRepository : BaseRepository<User>,IUserRepository
    {
        public UserRepository(ApplicationDbContext context):base(context)
        {

        }

        public async Task<User> GetUserDetails(int id)
        {
            var result = await _context.Users.Where(x => x.Id == id)
                .Include(x => x.PhoneNumbers).ThenInclude(x => x.Type)
                .Include(x => x.Gender)
                .Include(x => x.City)
                .Include(x => x.UserConnections).ThenInclude(x => x.ConnectionType)
                .Include(x => x.UserConnections).ThenInclude(x => x.ConnectedUser)
                .SingleOrDefaultAsync();
            return result;
        }
        public async Task<List<User>> Filter(string firstName, string lastName, string personalNumber, int? pageIndex, int pageSize)
        {
            var result = _context.Users.AsQueryable();

            if (!string.IsNullOrEmpty(firstName))
            {
                result = result.Where(x => x.FirstName.Contains(firstName));
            }
            if (!string.IsNullOrWhiteSpace(lastName))
            {
                result = result.Where(x => x.LastName.Contains(lastName));
            }
            if (!string.IsNullOrWhiteSpace(personalNumber))
            {
                result = result.Where(x => x.LastName.Contains(personalNumber));
            }

            var pagedResult = result.Skip(((pageIndex ?? 1) - 1) * pageSize).Take(pageSize);
            
            return await pagedResult.ToListAsync();
        }

        public async Task<IEnumerable<UserConnectionsReportDto>> ConnectionsReport(int id)
        {
            var result = await _context.Users.Include(x => x.UserConnections)
                .ThenInclude(x => x.ConnectionType)
                .FirstOrDefaultAsync(x => x.Id == id);


            var groupedResult = result.UserConnections
                .GroupBy(x => x.ConnectionType.Name).Select(x => new UserConnectionsReportDto 
                { 
                    ConnectionType = x.Key, 
                    ConnectedUsersCount = x.Count() 
                });

            return groupedResult;
        }

        public async Task<List<User>> AdvancedFilter(UserFilter filter,int? pageIndex, int pageSize)
        {
            var result = _context.Users.Include(x => x.City).Include(x => x.PhoneNumbers).ThenInclude(x => x.Phone).Include(x => x.Gender).AsQueryable();

            if (!string.IsNullOrEmpty(filter.FirstName))
            {
                result = result.Where(x => x.FirstName.Contains(filter.FirstName));
            }
            if (!string.IsNullOrWhiteSpace(filter.LastName))
            {
                result = result.Where(x => x.LastName.Contains(filter.LastName));
            }
            if (!string.IsNullOrWhiteSpace(filter.PersonalNumber))
            {
                result = result.Where(x => x.LastName.Contains(filter.PersonalNumber));
            }
            if (!string.IsNullOrWhiteSpace(filter.Phone))
            {
                result = result.Where(x => x.PhoneNumbers.Any(ph => ph.Phone.Contains(filter.Phone)));
            }

            if (!string.IsNullOrWhiteSpace(filter.Gender))
            {
                result = result.Where(x => x.Gender.Value.Contains(filter.Gender));
            }
            if (!string.IsNullOrWhiteSpace(filter.City))
            {
                result = result.Where(x => x.City.Name.Contains(filter.City));
            }


            var pagedResult = result.Skip(((pageIndex ?? 1) - 1) * pageSize).Take(pageSize);

            return await pagedResult.ToListAsync();
        }
    }
}
