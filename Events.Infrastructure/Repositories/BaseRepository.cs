using Events.Domain.Abstractions;
using Events.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Events.Infrastructure.Repositories
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : Entity
    {
        protected readonly DbSet<T> _entities;
        protected readonly ApplicationDbContext _context;
        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }
        public virtual async Task CreateAsync(T entity, CancellationToken token = default)
        {
            await _entities.AddAsync(entity);
        }

        public Task DeleteAsync(T entity, CancellationToken token = default)
        {
            _entities.Remove(entity);
            return Task.CompletedTask;
        }

        public virtual Task<IQueryable<T>> GetAllAsync(CancellationToken token = default)
        {
            return Task.FromResult(_entities.AsNoTracking().AsQueryable());
        }

        public virtual async Task<T?> GetByIdAsync(Guid id, CancellationToken token = default)
        {
            var entity = await _entities.AsNoTracking().FirstOrDefaultAsync(e => e.Id == id, token);
            return entity;
        }

        public virtual Task UpdateAsync(T entity, CancellationToken token = default)
        {
            _entities.Update(entity);
            return Task.CompletedTask;
        }
    }
}
