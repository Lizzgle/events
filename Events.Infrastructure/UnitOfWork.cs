using Events.Domain.Abstractions;
using Events.Infrastructure.Repositories;

namespace Events.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;

        private IUserRepository _users;
        private IParticipantRepository _participants;
        private IEventRepository _events;

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IUserRepository userRepository => _users ??= new UserRepository(_dbContext);
        public IParticipantRepository participantRepository => _participants ??= new ParticipantRepository(_dbContext);
        public IEventRepository eventRepository => _events ??= new EventRepository(_dbContext);

        public Task<int> SaveChangesAsync(CancellationToken token)
        {
            return _dbContext.SaveChangesAsync(token);
        }
    }
}
