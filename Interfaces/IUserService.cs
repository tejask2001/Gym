using CodingChallenge.Models;

namespace Gym.Interfaces
{
    public interface IUserService
    {
        public Task<User> AddUser(User user); 
        public Task<bool> RemoveUser(User user);
        public Task<User> GetUser(int userId);
        public Task<List<User>> GetAllUser();
        public Task<User> UpdateUser(User user);
    }
}
