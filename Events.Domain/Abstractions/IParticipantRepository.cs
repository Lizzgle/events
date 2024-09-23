using Events.Domain.Entities;

namespace Events.Domain.Abstractions
{
    public interface IParticipantRepository : IBaseRepository<Participant>
    {
        Task AddUserToEvent(Guid userId, Guid eventId, CancellationToken token);
        Task RemoveUserFromEvent(Guid userId, Guid eventId, CancellationToken token);
    }
}
