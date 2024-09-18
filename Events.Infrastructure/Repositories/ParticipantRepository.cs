using Events.Domain.Abstractions;
using Events.Domain.Entities;

namespace Events.Infrastructure.Repositories
{
    internal class ParticipantRepository : BaseRepository<Participant>, IParticipantRepository
    {
        private ApplicationDbContext dbContext;

        public ParticipantRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public Task AddUserToEvent(int userId, int eventId, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<Event> GetEventByIdWithParticipants(int id, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task RemoveUserFromEvent(int userId, int eventId, CancellationToken token)
        {
            throw new NotImplementedException();
        }
    }
}