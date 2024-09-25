using MediatR;

namespace Events.Application.Participants.Commands.RemoveUserFromEvent
{
    public class RemoveUserFromEventCommand : IRequest
    {
        public required Guid EventId { get; set; }
        public required Guid UserId { get; set; }
    }
}
