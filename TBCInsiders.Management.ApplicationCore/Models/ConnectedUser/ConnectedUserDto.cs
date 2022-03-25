using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBCInsiders.Management.ApplicationCore.Models.ConnectedUser
{
    public class ConnectedUserDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string PersonalNumber { get; set; }
        public int ConnectionTypeId { get; set; }

        //TODO: REPLICATE THIS.

    }
}
