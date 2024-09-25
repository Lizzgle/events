using MediatR;

namespace Events.Application.Users.Commands.Registration
{
    public class RegistrationCommand : IRequest<RegistrationCommandResponse>
    {
        public required string Name { get; set; }
        public required string Surname { get; set; }
        public required string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
