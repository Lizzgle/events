using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events.Application.Users.Commands.Registration
{
    public class RegistrationCommandResponse
    {
        public string JwtToken { get; init; } = string.Empty;

        public string RefreshToken { get; init; } = string.Empty;
    }
}
