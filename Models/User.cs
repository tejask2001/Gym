using System.ComponentModel.DataAnnotations;

namespace CodingChallenge.Models
{
    public class User
    {
        [Key] 
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public bool isAdmin { get; set; }

        public User()
        {
            
        }

        public User(int userId, string userName, string password, string email, bool isAdmin)
        {
            UserId = userId;
            UserName = userName;
            Password = password;
            Email = email;
            this.isAdmin = isAdmin;
        }
    }
}
