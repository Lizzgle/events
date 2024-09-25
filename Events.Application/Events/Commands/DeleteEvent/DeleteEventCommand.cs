using MediatR;

namespace Events.Application.Events.Commands.DeleteEvent
{
    public record DeleteEventCommand : IRequest
    {
        public required Guid Id { get; set; }
    }
}
