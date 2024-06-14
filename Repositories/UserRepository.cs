using CodingChallenge.Context;
using CodingChallenge.Exceptions;
using CodingChallenge.Interfaces;
using CodingChallenge.Models;
using CodingChallenge.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Gym.Repositories
{
    public class UserRepository : IRepository<int, User>
    {
        private readonly RequestTrackerContext _context;
        ILogger<UserRepository> _logger;

        public UserRepository(RequestTrackerContext context, ILogger<UserRepository> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<User> Add(User items)
        {
            _context.Add(items);
            _context.SaveChanges();
            _logger.LogInformation("User added with id " + items.UserId);
            return items;
        }

        public async Task<User> Delete(int key)
        {
            var user = await GetAsync(key);
            if (user != null)
            {
                _context.Remove(key);
                _logger.LogInformation("User deleted with id " + key);
                return user;
            }
            throw new NoSuchUserException();
        }

        public async Task<User> GetAsync(int key)
        {
            var users = await GetAsync();
            var user = users.FirstOrDefault(e => e.UserId == key);
            return user;
        }

        public async Task<List<User>> GetAsync()
        {
            return _context.Users.ToList();
        }

        public async Task<User> Update(User items)
        {
            var user = await GetAsync(items.UserId);
            if (user != null)
            {
                _context.Entry<User>(items).State = EntityState.Modified;
                _context.SaveChanges();
                _logger.LogInformation("User updated with id " + items.UserId);
                return user;
            }
            throw new NoSuchUserException();
        }
    }
}
