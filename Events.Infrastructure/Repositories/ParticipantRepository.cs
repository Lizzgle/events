using Events.Domain.Abstractions;
using Events.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Events.Infrastructure.Repositories
{
    internal class ParticipantRepository : BaseRepository<Participant>, IParticipantRepository
    {
        
        public ParticipantRepository(ApplicationDbContext dbContext) : base(dbContext) { }

        public async Task AddUserToEvent(Guid userId, Guid eventId, CancellationToken token)
        {
            var participant = new Participant
            {
                UserId = userId,
                EventId = eventId,
                DateOfRegistration = DateTime.UtcNow
            };

            await _entities.AddAsync(participant);
        }

        public async Task RemoveUserFromEvent(Guid userId, Guid eventId, CancellationToken token)
        {
            var participant = await _entities.FirstOrDefaultAsync(p => p.UserId == userId && p.EventId == eventId);
            if (participant is not null)
                _entities.Remove(participant);
        }
    }
}