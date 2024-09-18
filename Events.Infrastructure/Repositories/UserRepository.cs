using Events.Domain.Abstractions;
using Events.Domain.Entities;

namespace Events.Infrastructure.Repositories
{
    internal class UserRepository : BaseRepository<User>, IUserRepository
    {
       
        public UserRepository(ApplicationDbContext context) : base(context)
        {
           
        }

        public Task<IEnumerable<Participant>> GetUserEvents(int userId)
        {
            throw new NotImplementedException();
        }
    }
}