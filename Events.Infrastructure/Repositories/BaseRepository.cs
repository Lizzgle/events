using Events.Domain.Abstractions;
using Events.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public async Task CreateAsync(T entity, CancellationToken token = default)
        {
            await _entities.AddAsync(entity);
        }

        public async Task DeleteAsync(T entity, CancellationToken token = default)
        {
            _entities.Remove(entity);
            await Task.CompletedTask;
        }

        public async Task<IQueryable<T>> GetAllAsync(CancellationToken token = default)
        {
            var query = await _entities.ToListAsync(token);
            return query.AsQueryable();
        }

        public async Task<T> GetByIdAsync(Guid id, CancellationToken token = default)
        {
            var entity = await _entities.FindAsync(id);
            if (entity is null)
                throw new ArgumentException("Entity not found");
            return entity;
        }

        public async Task UpdateAsync(T entity, CancellationToken token = default)
        {
            _entities.Update(entity);
            await Task.CompletedTask;
        }
    }
}
