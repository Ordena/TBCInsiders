using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using TBCInsiders.Management.ApplicationCore.Models.Filters;
using TBCInsiders.Management.ApplicationCore.Models.User;

namespace TBCInsiders.Management.ApplicationCore.Interfaces.Services
{
    public interface IUserService
    {
       
        Task<UserDetailsDto> GetUserDetailsAsync(int id);
        Task<List<UserDto>> Filter(string firstName, string lastName, string personalNumber, int? pageIndex, int pageSize);
        Task<UserDto> GetUserAsync(int id);
        Task AddUserAsync(CreateUserDto request);
        Task AddUserAsync(CreateUserDto request,IFormFile file);
        Task UpdateUserAsync(EditUserDto request);
        
        Task DeleteAsync(int id);
        Task<IEnumerable<UserConnectionsReportDto>> GetReportAsync(int id);
        Task<IEnumerable<UserDetailsDto>> AdvancedFilter(UserFilter filter, int? pageIndex, int pageSize);
        
    }
}
