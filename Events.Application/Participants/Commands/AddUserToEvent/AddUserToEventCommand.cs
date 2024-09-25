using MediatR;

namespace Events.Application.Participants.Commands.AddUserToEvent
{
    public class AddUserToEventCommand : IRequest
    {
        public required Guid EventId { get; set; }
        public required Guid UserId { get; set;}
        public DateTime DateOfRegistration { get; set; } = DateTime.UtcNow;
    }
}
