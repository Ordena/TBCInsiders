
namespace TBCInsiders.Management.Domain.Entities
{
    public class PhoneNumber
    {
        public int Id { get; set; }
        public string Phone { get; set; }
        public int TypeID { get; set; }
        public PhoneNumberType Type { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}