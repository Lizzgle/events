using Events.Application.Common.DTOs;
using MediatR;

namespace Events.Application.Events.Queries.GetEventByName
{
    public record GetEventByNameQuery : IRequest<EventDTO>
    {
        public required string Name { get; set; }
    }
}
