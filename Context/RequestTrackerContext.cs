using CodingChallenge.Models;
using Microsoft.EntityFrameworkCore;

namespace CodingChallenge.Context
{
    public class RequestTrackerContext:DbContext
    {
        public DbSet<Member> Members { get; set; }
        public DbSet<User> Users { get; set; }
        public RequestTrackerContext(DbContextOptions options) : base(options)
        {

        }
    }
}
