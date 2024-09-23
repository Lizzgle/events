using Events.Domain.Entities;

namespace Events.Domain.Abstractions
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User?> GetUserByEmail(string email, CancellationToken token);
        Task<IEnumerable<Participant>> GetUserEvents(Guid userId, CancellationToken token = default);

        //Task<Participant> AddUserToEvent(Guid userId, Guid eventId, CancellationToken token);
        //Task RemoveUserFromEvent(Guid userId, Guid eventId, CancellationToken token);
    }
}
