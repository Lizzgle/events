using Events.Domain.Abstractions;
using Events.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Events.Infrastructure.Repositories
{
    public class EventRepository : BaseRepository<Event>, IEventRepository
    {
        public EventRepository(ApplicationDbContext dbContext) : base(dbContext) { }

        public async Task<int> CountOfParticipantsAsync(Guid eventId, CancellationToken token = default)
        {
            return await _context.Participants.Where(p => p.EventId == eventId).CountAsync();
        }

        public async Task<Event?> GetEventByNameAsync(string name, CancellationToken token = default)
        {
            return await _entities.AsNoTracking().FirstOrDefaultAsync(e => e.Name == name, token);
        }
    }
}