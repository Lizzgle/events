using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events.Application.Users.Commands.Login
{
    public class LoginCommandResponse
    {
        public string JwtToken { get; init; } = string.Empty;
        public string RefreshToken { get; init; } = string.Empty;

        public bool IsLogin { get; init; } = false;
    }
}
