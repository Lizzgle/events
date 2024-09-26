using Events.Domain.Abstractions;
using Events.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Events.Infrastructure.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context) { }

        public Task<User?> GetUserByEmailAsync(string email, CancellationToken token)
        {
            return _entities.AsNoTracking().Include(r => r.Roles).FirstOrDefaultAsync(e => e.Email == email, token);
        }

        public async Task<IEnumerable<Event>> GetUserEventsAsync(Guid userId, CancellationToken token = default)
        {
            return await _context.Events.Where(e => e.Participants.Any(p => p.UserId == userId)).ToListAsync(token);
        }

        public override Task UpdateAsync(User entity, CancellationToken token = default)
        {
            _entities.Attach(entity);

            return base.UpdateAsync(entity, token);
        }

        public override Task CreateAsync(User entity, CancellationToken token = default)
        {
            if (entity.Roles.Count != 0)
            {
                _context.Roles.AttachRange(entity.Roles);
            }

            return base.UpdateAsync(entity, token);
        }

        public override Task<User?> GetByIdAsync(Guid id, CancellationToken token = default)
        {
            return _entities.Include(r => r.Roles).FirstOrDefaultAsync(e => e.Id == id, token);
        }
    }
}