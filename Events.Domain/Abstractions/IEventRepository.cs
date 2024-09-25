using Events.Domain.Entities;

namespace Events.Domain.Abstractions
{
    public interface IEventRepository : IBaseRepository<Event>
    {
        Task<Event?> GetEventByNameAsync(string name, CancellationToken token = default);

        Task<int> CountOfParticipantsAsync(Guid eventId, CancellationToken token = default);

    }
}
