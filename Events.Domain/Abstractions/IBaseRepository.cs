using Events.Domain.Entities;

namespace Events.Domain.Abstractions
{
    public interface IBaseRepository<T> where T : Entity
    {
        public Task<IQueryable<T>> GetAllAsync(CancellationToken token = default);

        public Task<T?> GetByIdAsync(Guid id, CancellationToken token = default);

        public Task CreateAsync(T entity, CancellationToken token = default);
        public Task UpdateAsync(T entity, CancellationToken token = default);
        public Task DeleteAsync(T entity, CancellationToken token = default);

    }
}
