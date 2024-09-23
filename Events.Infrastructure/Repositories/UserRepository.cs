using Events.Domain.Abstractions;
using Events.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Events.Infrastructure.Repositories
{
    internal class UserRepository : BaseRepository<User>, IUserRepository
    {
       
        public UserRepository(ApplicationDbContext context) : base(context) { }

        public Task<User?> GetUserByEmail(string email, CancellationToken token)
        {
            return _entities.FirstOrDefaultAsync(e => e.Email == email, token);
        }

        public Task<IEnumerable<Participant>> GetUserEvents(Guid userId, CancellationToken token = default)
        {
            throw new NotImplementedException();
        }

        //public async Task<Participant> AddUserToEvent(Guid userId, Guid eventId, CancellationToken token)
        //{
        //    var participant = new Participant
        //    {
        //        UserId = userId,
        //        EventId = eventId,
        //        DateOfRegistration = DateTime.UtcNow
        //    };
        //    await
        //}

        //public async Task RemoveUserFromEvent(Guid userId, Guid eventId, CancellationToken token)
        //{
        //    var participant = await _entities.FirstOrDefaultAsync(p => p.UserId == userId && p.EventId == eventId);
        //    if (participant is not null)
        //        _entities.Remove(participant);
        //}
    }
}