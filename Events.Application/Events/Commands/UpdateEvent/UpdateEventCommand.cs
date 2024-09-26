using Events.Domain.Entities;
using MediatR;

namespace Events.Application.Events.Commands.UpdateEvent
{
    public record UpdateEventCommand : IRequest
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required DateTime DateTime { get; set; }
        public required string Location { get; set; }
        public required Category Category { get; set; }
        public required int MaxParticipants { get; set; }
    }
}
