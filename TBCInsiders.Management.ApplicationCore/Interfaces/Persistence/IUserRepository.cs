using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBCInsiders.Management.ApplicationCore.Models.Filters;
using TBCInsiders.Management.ApplicationCore.Models.User;
using TBCInsiders.Management.Domain.Entities;

namespace TBCInsiders.Management.ApplicationCore.Interfaces.Persistence
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        Task<User> GetUserDetails(int id);
        Task<List<User>> Filter(string firstName, string lastName, string personalNumber,int? pageIndex, int pageSize);
        Task<IEnumerable<UserConnectionsReportDto>> ConnectionsReport(int id);
        Task<List<User>> AdvancedFilter(UserFilter filter, int? pageIndex, int pageSize);
    }
}
