using Events.Application.Common;
using Events.Application.Common.DTOs.EventDTO;
using Events.Application.Common.DTOs.UserDTO;
using Events.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events.Application.Users.Queries.GetUserEvents
{
    public class GetUserEventsQuery : IRequest<PaginatedResult<EventDTOWithoutParticipants>>
    {
        public required Guid Id { get; set; }

        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
