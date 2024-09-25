using Events.Application.Common.DTOs;
using Events.Application.Common.Models;
using MediatR;

namespace Events.Application.Events.Queries.GetEventByIdWithParticipants
{
    public class GetParticipantsByEventIdQuery : IRequest<PaginatedResult<ParticipantDTO>>
    {
        public required Guid Id { get; set; }

        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
