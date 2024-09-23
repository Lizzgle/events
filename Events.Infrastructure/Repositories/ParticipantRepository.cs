using Events.Domain.Abstractions;
using Events.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Events.Infrastructure.Repositories
{
    internal class ParticipantRepository : BaseRepository<Participant>, IParticipantRepository
    {
        
        public ParticipantRepository(ApplicationDbContext dbContext) : base(dbContext) { }

        public async Task<IQueryable<Participant>> GetByEventIdAsync(Guid id)
        {
            var query = await _entities.Include(p => p.User).Where(p => p.EventId == id).ToListAsync();
            return query.AsQueryable();
        }

        public async Task<Participant> GetByUserAndByEventAsync(Guid userId, Guid eventId, CancellationToken token = default)
        {
            return await _entities.AsNoTracking().FirstAsync(p => p.UserId == userId && p.EventId == eventId);
        }
    }
}