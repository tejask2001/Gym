using CodingChallenge.Exceptions;
using CodingChallenge.Interfaces;
using CodingChallenge.Models;
using Gym.Interfaces;

namespace Gym.Services
{
    public class MemberService : IMemberService
    {
        private readonly IRepository<int,Member> _members;

        public MemberService(IRepository<int, Member> members)
        {
            _members = members;   
        }
        public Task<Member> AddMember(Member member)
        {
           return _members.Add(member);
        }

        public Task<List<Member>> GetAllMember()
        {
            return _members.GetAsync();
        }

        public async Task<Member> GetMember(int memberId)
        {
            var member=await _members.GetAsync(memberId);
            if (member != null)
            {
                return member;
            }
            throw new NoSuchUserException();
        }

        public async Task<bool> RemoveMember(Member member)
        {
            var members = await _members.GetAsync(member.MemberId);
            if (member != null)
            {
                _members.Delete(member.MemberId);
                return true;
            }
            throw new NoSuchUserException();
        }

        public async Task<Member> UpdateMember(Member member)
        {
            var members = await _members.GetAsync(member.MemberId);
            if (member != null)
            {
                members.Email = member.Email;
                members.MembershipExpiry=member.MembershipExpiry;
                members.DateOfJoining=member.DateOfJoining; 
                members.Name=member.Name;
                member.Phone = member.Phone;
                return await _members.Update(members);
            }
            throw new NoSuchUserException();
        }
    }
}
