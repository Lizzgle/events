using Events.Domain.Entities;

namespace Events.Domain.Abstractions
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<IEnumerable<Participant>> GetUserEvents(int userId);
    }
}
