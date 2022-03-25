using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBCInsiders.Management.ApplicationCore.Models.User
{
    public class AddContactDto
    {
        public int UserId { get; set; }
        public CreateUserDto Contact { get; set; }
    }
}
