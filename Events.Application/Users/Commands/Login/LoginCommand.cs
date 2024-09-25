using MediatR;

namespace Events.Application.Users.Commands.Login
{
    public class LoginCommand : IRequest<LoginCommandResponse>
    {
        public required string Email { get; set; }
    }
}
