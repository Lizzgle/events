﻿using Events.Domain.Entities;
using MediatR;

namespace Events.Application.Events.Commands.CreateEvent
{
    public record CreateEventCommand : IRequest
    {
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required DateTime DateTime { get; set; }
        public required string Location { get; set; }
        public required int CategoryId { get; set; }
        public required int MaxParticipants { get; set; }
        public required string UriImage { get; set; }
    }
}
