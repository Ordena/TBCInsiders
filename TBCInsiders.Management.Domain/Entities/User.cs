using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBCInsiders.Management.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PersonalNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
   
        public int? ImageId { get; set; }
        public Image Image{ get; set; }
        
        public string ImagePath { get; set; }
        public int? GenderId { get; set; }
        public Gender Gender { get; set; }
        public int? CityId { get; set; }
        public City City { get; set; }

        public ICollection<PhoneNumber> PhoneNumbers { get; set; }
        public ICollection<UserConnections> UserConnections { get; set; }

        public User()
        {
            PhoneNumbers = new HashSet<PhoneNumber>();
            UserConnections = new HashSet<UserConnections>();
        }


    }
}
