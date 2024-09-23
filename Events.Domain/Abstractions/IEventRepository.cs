using Events.Domain.Entities;

namespace Events.Domain.Abstractions
{
    public interface IEventRepository : IBaseRepository<Event>
    {
        Task<IQueryable<Event>> GetEventsByCriteria(DateTime? date, 
            Category? category, string? location, CancellationToken token = default);

        Task<Event?> GetEventByName(string name, CancellationToken token);

    }
}
