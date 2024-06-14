using CodingChallenge.Exceptions;
using CodingChallenge.Interfaces;
using CodingChallenge.Models;
using Gym.Interfaces;

namespace Gym.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<int, Member> _members;
        private readonly IRepository<int, User> _user;

        public UserService(IRepository<int, Member> members, IRepository<int, User> user)
        {
            _members = members;
            _user = user;
        }
        public async Task<User> AddUser(User user)
        {
                return await _user.Add(user);
        }

        public async Task<List<User>> GetAllUser()
        {
            return await _user.GetAsync();
        }

        public async Task<User> GetUser(int userId)
        {
            var user=await _user.GetAsync(userId);
            if (user != null)
            {
                return user;
            }
            throw new NoSuchUserException();
        }

        public async Task<bool> RemoveUser(User user)
        {
            var users = await _user.GetAsync(user.UserId);
            if (users != null)
            {
                _user.Delete(user.UserId);
                return true;
            }
            throw new NoSuchUserException();
        }

        public async Task<User> UpdateUser(User user)
        {
            var users = await _user.GetAsync(user.UserId);
            if (users != null)
            {
                users.Email=user.Email;
                users.Password = user.Password;
                return await _user.Update(users);
            }
            throw new NoSuchUserException();
        }
    }
}
