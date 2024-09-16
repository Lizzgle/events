using Events.Domain.Entities;

namespace Events.Domain.Abstractions
{
    public interface IEventRepository : IBaseRepository<Event>
    {
        Task<IEnumerable<Event>> GetEventsByCriteria(string name, DateTime? date, 
            string category, string location, CancellationToken token);

        Task<Event> GetEventByName(string name, CancellationToken token);

        public Task SaveImageAsync(Event @event, string image, CancellationToken token);
    }
}
