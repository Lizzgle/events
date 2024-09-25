using Events.Domain.Entities;

namespace Events.Domain.Abstractions
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User?> GetUserByEmailAsync(string email, CancellationToken token);
        Task<IEnumerable<Event>> GetUserEventsAsync(Guid userId, CancellationToken token = default);

    }
}
