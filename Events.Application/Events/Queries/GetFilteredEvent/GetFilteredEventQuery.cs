using Events.Application.Common.DTOs;
using Events.Application.Common.Models;
using Events.Domain.Enums;
using MediatR;

namespace Events.Application.Events.Queries.GetFilteredEvent
{
    public record GetFilteredEventQuery : IRequest<PaginatedResult<EventDTO>>
    {
        public string? Location { get; set; }
        public DateTime? Date { get; set; }
        public Category? Category { get; set; }

        public required int PageSize { get; init; }
        public required int PageNumber { get; init; }
    }
}
