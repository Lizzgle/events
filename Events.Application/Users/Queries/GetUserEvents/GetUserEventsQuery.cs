using Events.Application.Common.DTOs.UserDTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events.Application.Users.Queries.GetUserEvents
{
    public class GetUserEventsQuery : IRequest<UserDTO>
    {
        public required Guid Id { get; set; }
    }
}
