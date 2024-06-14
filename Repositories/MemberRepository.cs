using CodingChallenge.Context;
using CodingChallenge.Exceptions;
using CodingChallenge.Interfaces;
using CodingChallenge.Models;
using Microsoft.EntityFrameworkCore;

namespace CodingChallenge.Repositories
{
    public class MemberRepository : IRepository<int, Member>
    {
        private readonly RequestTrackerContext _context;
        ILogger<MemberRepository> _logger;

        public MemberRepository(RequestTrackerContext context, ILogger<MemberRepository> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<Member> Add(Member items)
        {
            _context.Add(items);
            _context.SaveChanges();
            _logger.LogInformation("Member added with id " + items.MemberId);
            return items;
        }

        public async Task<Member> Delete(int key)
        {
            var member=await GetAsync(key);
            if (member != null)
            {
                _context.Remove(key);
                _logger.LogInformation("Member deleted with id " + key);
                return member;
            }
            throw new NoSuchUserException();
        }

        public async Task<Member> GetAsync(int key)
        {
            var members = await GetAsync();
            var member=members.FirstOrDefault(e=>e.MemberId==key);
            return member;
        }

        public async Task<List<Member>> GetAsync()
        {
            return _context.Members.ToList();
        }

        public async Task<Member> Update(Member items)
        {
            var member= await GetAsync(items.MemberId);
            if(member != null)
            {
                _context.Entry<Member>(items).State = EntityState.Modified;
                _context.SaveChanges();
                _logger.LogInformation("Member updated with id " + items.MemberId);
                return member;
            }
            throw new NoSuchUserException();
        }

    }
}
