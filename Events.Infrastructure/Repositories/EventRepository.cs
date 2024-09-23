using Events.Domain.Abstractions;
using Events.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Events.Infrastructure.Repositories
{
    internal class EventRepository : BaseRepository<Event>, IEventRepository
    {
        public EventRepository(ApplicationDbContext dbContext) : base(dbContext) { }

        public async Task<Event?> GetEventByName(string name, CancellationToken token)
        {
            return await _entities.FirstOrDefaultAsync(e => e.Name == name, token);
        }

        public async Task<IQueryable<Event>> GetEventsByCriteria(DateTime? date, Category? category, string? location, CancellationToken token = default)
        {
            IQueryable<Event> query = _entities;

            if (date.HasValue)
                query = query.Where(e => e.DateTime.Date == date);

            if (category.HasValue)
                query = query.Where(e => e.Category == category);

            if (!string.IsNullOrEmpty(location))
                query = query.Where(e => e.Location == location);

            return query;
        }
    }
}