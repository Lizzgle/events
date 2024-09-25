using Events.Application.Common.DTOs;
using Events.Application.Common.Models;
using MediatR;

namespace Events.Application.Users.Queries.GetUserEvents
{
    public class GetUserEventsQuery : IRequest<PaginatedResult<EventDTO>>
    {
        public required Guid Id { get; set; }

        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
