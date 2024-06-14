namespace Gym.Models
{
    public class AddMemberDTO
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public bool isAdmin { get; set; }

        public string Name { get; set; }
        public string Phone { get; set; }
        public DateTime MembershipExpiry { get; set; }
        public DateTime DateOfJoining { get; set; }
    }
}
