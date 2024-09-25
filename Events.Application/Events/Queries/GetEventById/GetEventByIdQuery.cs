using Events.Application.Common.DTOs;
using MediatR;

namespace Events.Application.Events.Queries.GetEventById
{
    public record GetEventByIdQuery : IRequest<EventDTO>
    {
        public required Guid Id { get; set; }
    }
}
