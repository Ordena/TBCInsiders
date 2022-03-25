using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBCInsiders.Management.ApplicationCore.Models.ConnectedUser;
using TBCInsiders.Management.ApplicationCore.Models.ConnectionType;

namespace TBCInsiders.Management.ApplicationCore.Models.UserConnection
{
    public class UserConnectionDto
    {
        public int Id { get; set; }
        public ConnectedUserDto ConnectedUser { get; set; }
        public ConnectionTypeDto ConnectionType { get; set; }
    }
}
