using CodingChallenge.Models;

namespace Gym.Interfaces
{
    public interface IMemberService
    {
        public Task<Member> AddMember(Member member);
        public Task<bool> RemoveMember(Member member);
        public Task<Member> GetMember(int memberId);
        public Task<List<Member>> GetAllMember();
        public Task<Member> UpdateMember(Member member);
    }
}
