using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events.Application.Participants.Commands.AddUserToEvent
{
    public class AddUserToEventCommand : IRequest
    {
        public required Guid EventId { get; set; }
        public required Guid UserId { get; set;}
        public DateTime DateOfRegistration { get; set; } = DateTime.UtcNow;
    }
}
