using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TBCInsiders.Management.Web.Models
{
    public class UserDetailViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<string> PhoneNumber { get; set; }
        public string PersonalNumber { get; set; }
        public string DateOfBirth { get; set; }
        public string ImagePath { get; set; }
        public string Gender { get; set; }
        public string City { get; set; }

    }
}
