using Events.Domain.Abstractions;
using Events.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Events.Infrastructure.Repositories
{
    public class ParticipantRepository : BaseRepository<Participant>, IParticipantRepository
    {
        public ParticipantRepository(ApplicationDbContext dbContext) : base(dbContext) { }

        public Task<IQueryable<Participant>> GetByEventIdAsync(Guid eventId, CancellationToken token = default)
        {
            var query = _entities.AsNoTracking().Include(p => p.User).Where(p => p.EventId == eventId).AsQueryable();
            return Task.FromResult(query);
        }

        public async Task<Participant> GetByUserAndByEventAsync(Guid userId, Guid eventId, CancellationToken token = default)
        {
            return await _entities.AsNoTracking().FirstAsync(p => p.UserId == userId && p.EventId == eventId);
        }
    }
}