using Events.Application.Common.DTOs;
using Events.Application.Common.Models;
using MediatR;

namespace Events.Application.Events.Queries.GetAllEvents
{
    public record GetAllEventsQuery : IRequest<PaginatedResult<EventDTO>>
    {
        public required int PageSize { get; init; }
        public required int PageNumber { get; init; }
    }
}
