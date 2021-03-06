using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBCInsiders.Management.ApplicationCore.Interfaces.Persistence;
using TBCInsiders.Management.ApplicationCore.Models.ConnectedUser;
using TBCInsiders.Management.Domain.Entities;

namespace TBCInsiders.Management.ApplicationCore.Interfaces.Services
{
    public class UserConnectionService : IUserConnectionService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        public UserConnectionService(IUnitOfWork uow,IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public async Task AddConnectedUser(int userId, ConnectedUserDto connectedUser)
        {

            var existingUser = await _uow.Users.GetAsync(userId);
            var userTobeConnected = _mapper.Map<ConnectedUser>(connectedUser);

            var userConnection = new UserConnections { UserId = existingUser.Id, ConnectedUser = userTobeConnected, ConnectionTypeId = connectedUser.ConnectionTypeId };
            existingUser.UserConnections.Add(userConnection);

            await _uow.CommitAsync();

        }
    }
}
