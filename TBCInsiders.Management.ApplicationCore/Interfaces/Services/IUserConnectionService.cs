using System.Threading.Tasks;
using TBCInsiders.Management.ApplicationCore.Models.ConnectedUser;

namespace TBCInsiders.Management.ApplicationCore.Interfaces.Services
{
    public interface IUserConnectionService
    {
        Task AddConnectedUser(int userId, ConnectedUserDto connectedUser);
        Task RemoveConnectionAsync(int userConnectionId);
    }
}
