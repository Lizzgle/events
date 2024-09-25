using Events.Domain.Entities;

namespace Events.Domain.Abstractions
{
    public interface IParticipantRepository : IBaseRepository<Participant>
    {
        Task<IQueryable<Participant>> GetByEventIdAsync(Guid eventId, CancellationToken token = default);

        Task<Participant> GetByUserAndByEventAsync(Guid userId, Guid eventId, CancellationToken token = default);
    }
}
