using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBCInsiders.Management.Domain.Entities
{
    public class UserConnections
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
        public int ConnectedUserId { get; set; }
        public ConnectedUser ConnectedUser { get; set; }
        //public User ConnectedUser { get; set; }

        public int ConnectionTypeId { get; set; }
        public UserConnectionType ConnectionType { get; set; }

    }
}
