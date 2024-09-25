namespace Events.Domain.Abstractions
{
    public interface IUnitOfWork
    {
        IUserRepository userRepository { get; }
        IParticipantRepository participantRepository { get; }
        IEventRepository eventRepository { get; }

        public Task<int> SaveChangesAsync(CancellationToken token = default);
    }
}
