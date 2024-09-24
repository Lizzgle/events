using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events.Application.Users.Commands.Login
{
    public class LoginCommand : IRequest<LoginCommandResponse>
    {
        public required string Email { get; set; }
    }
}
