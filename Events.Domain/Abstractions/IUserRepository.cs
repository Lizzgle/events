using Events.Domain.Entities;

namespace Events.Domain.Abstractions
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User?> GetUserByEmail(string email, CancellationToken token);
        Task<IEnumerable<Event>> GetUserEvents(Guid userId, CancellationToken token = default);

    }
}
