using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events.Application.Users.Commands.AddToEvent
{
    internal class AddToEventCommand : IRequest
    {
        public required Guid UserId { get; set; }
        public required Guid EventId { get; set; }
    }
}
