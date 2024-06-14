using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodingChallenge.Models
{
    public class Member
    {
        [Key]
        public int MemberId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime MembershipExpiry { get; set; }
        public DateTime DateOfJoining { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }

        public Member()
        {
            
        }
        public Member(int memberId, string name, string email, string phone, DateTime membershipExpiry, DateTime dateOfJoining)
        {
            MemberId = memberId;
            Name = name;
            Email = email;
            Phone = phone;
            MembershipExpiry = membershipExpiry;
            DateOfJoining = dateOfJoining;
        }
    }
}
