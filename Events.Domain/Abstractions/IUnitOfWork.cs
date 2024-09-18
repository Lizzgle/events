namespace Events.Domain.Abstractions
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; }
        IParticipantRepository Participants { get; }
        IEventRepository Events { get; }
        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
