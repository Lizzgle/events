using Events.Application.Common.DTOs.EventDTO;
using Events.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events.Application.Events.Queries.GetEventsByCriteria
{
    public record GetEventsByCriteria : IRequest<IEnumerable<EventDTO>>
    {
        public string? Location { get; set; }
        public DateTime? Date { get; set; }
        public Category? Category { get; set; }
    }
}
