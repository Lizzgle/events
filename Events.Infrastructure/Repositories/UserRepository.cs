using Events.Domain.Abstractions;
using Events.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Events.Infrastructure.Repositories
{
    internal class UserRepository : BaseRepository<User>, IUserRepository
    {
       
        public UserRepository(ApplicationDbContext context) : base(context) { }

        public Task<User?> GetUserByEmail(string email, CancellationToken token)
        {
            return _entities.Include(r => r.Roles).FirstOrDefaultAsync(e => e.Email == email, token);
        }

        public async Task<IEnumerable<Event>> GetUserEvents(Guid userId, CancellationToken token = default)
        {
            return await _context.Events.Where(e => e.Participants.Any(p => p.UserId == userId)).ToListAsync(token);
        }
    }
}