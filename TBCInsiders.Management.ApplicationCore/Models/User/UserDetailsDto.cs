using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBCInsiders.Management.ApplicationCore.Models.ConnectedUser;
using TBCInsiders.Management.ApplicationCore.Models.PhoneNumber;
using TBCInsiders.Management.ApplicationCore.Models.UserConnection;

namespace TBCInsiders.Management.ApplicationCore.Models.User
{
    public class UserDetailsDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PersonalNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string ImagePath { get; set; }
        public string Gender { get; set; }
        public string City { get; set; }
        public List<PhoneNumberDto> PhoneNumbers { get; set; }

        //TODO: ADD CONNECTIONS.
        //public List<ConnectedUserDto> UserConnections { get; set; }
        public List<UserConnectionDto> UserConnections { get; set; }
    }
}
