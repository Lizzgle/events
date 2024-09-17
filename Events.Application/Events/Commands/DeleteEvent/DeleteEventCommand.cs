using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events.Application.Events.Commands.DeleteEvent
{
    public record DeleteEventCommand : IRequest
    {
        public required Guid Id { get; set; }
    }
}
