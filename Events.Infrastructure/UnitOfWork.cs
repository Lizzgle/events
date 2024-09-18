using Events.Domain.Abstractions;
using Events.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public IUserRepository Users => _users ??= new UserRepository(_dbContext);
        public IParticipantRepository Participants => _participants ??= new ParticipantRepository(_dbContext);
        public IEventRepository Events => _events ??= new EventRepository(_dbContext);

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
