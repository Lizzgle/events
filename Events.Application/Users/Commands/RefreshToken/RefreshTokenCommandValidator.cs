using FluentValidation;

namespace Events.Application.Users.Commands.RefreshToken
{
    public class RefreshTokenCommandValidator : AbstractValidator<RefreshTokenCommand>
    {
        public RefreshTokenCommandValidator()
        {
            RuleFor(t => t.Jwt).NotEmpty();
        }
    }
}
