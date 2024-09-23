using Events.Application.Common;
using Events.Application.Common.DTOs.EventDTO;
using Events.Application.Common.DTOs.ParticipantDTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events.Application.Events.Queries.GetEventByIdWithParticipants
{
    public class GetParticipantsByEventIdQuery : IRequest<PaginatedResult<ParticipantDTOWithoutEvents>>
    {
        public required Guid Id { get; set; }

        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
