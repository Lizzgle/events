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
            return _entities.FirstOrDefaultAsync(e => e.Email == email, token);
        }

        public async Task<IEnumerable<Participant>> GetUserEvents(Guid userId, CancellationToken token = default)
        {
            return await _context.Participants.Where(p => p.UserId == userId).ToListAsync(token);
        }
    }
}