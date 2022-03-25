using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBCInsiders.Management.ApplicationCore.Models.User
{
    public class UserConnectionsReportDto
    {
        public string ConnectionType { get; set; }
        public int ConnectedUsersCount { get; set; }
    }
}
