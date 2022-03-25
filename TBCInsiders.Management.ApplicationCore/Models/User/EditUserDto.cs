using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBCInsiders.Management.ApplicationCore.Models.PhoneNumber;

namespace TBCInsiders.Management.ApplicationCore.Models.User
{
    public class EditUserDto

    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PersonalNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int GenderId { get; set; }
        public int CityId { get; set; }
        //public List<PhoneNumberDto> PhoneNumbers { get; set; }
    }
}
