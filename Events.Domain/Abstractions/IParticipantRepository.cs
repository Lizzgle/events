using Events.Domain.Entities;

namespace Events.Domain.Abstractions
{
    public interface IParticipantRepository : IBaseRepository<Participant>
    {
        Task<Event> GetEventByIdWithParticipants(int id, CancellationToken token);

        Task AddUserToEvent(int userId, int eventId, CancellationToken token);
        Task RemoveUserFromEvent(int userId, int eventId, CancellationToken token);
    }
}
