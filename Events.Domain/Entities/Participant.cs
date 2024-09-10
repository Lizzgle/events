namespace Events.Domain.Entities
{
    public class Participant : Entity
    {
        public Guid UserId { get; set; }
        public User User { get; set; }
        public Guid EventId { get; set; }
        public Event Event { get; set; }

        public DateTime DateOfRegistration { get; set; }
    }
}
