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

        public override Task UpdateAsync(Event entity, CancellationToken token = default)
        {
            if (entity.Category is not null)
            {
                _context.Categories.Attach(entity.Category);
            }

            return base.UpdateAsync(entity, token);
        }

        public override Task CreateAsync(Event entity, CancellationToken token = default)
        {
            if (entity.Category is not null)
            {
                _context.Categories.Attach(entity.Category);
            }

            return base.CreateAsync(entity, token);
        }

        public override Task<IQueryable<Event>> GetAllAsync(CancellationToken token = default)
        {

            return Task.FromResult(_entities.Include(e => e.Category).AsNoTracking().AsQueryable());
        }
    }
}