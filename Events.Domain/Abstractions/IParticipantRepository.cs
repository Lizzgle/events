using Events.Domain.Entities;

namespace Events.Domain.Abstractions
{
    public interface IParticipantRepository : IBaseRepository<Participant>
    {
        Task<IQueryable<Participant>> GetByEventIdAsync(Guid id);

        Task<Participant> GetByUserAndByEventAsync(Guid userId, Guid eventId, CancellationToken token = default);
    }
}
