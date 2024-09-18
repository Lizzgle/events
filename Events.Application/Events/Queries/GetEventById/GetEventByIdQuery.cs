using Events.Application.Common.DTOs.EventDTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events.Application.Events.Queries.GetEventById
{
    public record GetEventByIdQuery : IRequest<EventDTO>
    {
        public required Guid Id { get; set; }
    }
}
