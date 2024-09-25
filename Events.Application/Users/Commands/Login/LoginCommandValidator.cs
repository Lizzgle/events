using FluentValidation;

namespace Events.Application.Users.Commands.Login
{
    public class LoginCommandValidator : AbstractValidator<LoginCommand>
    {
        public LoginCommandValidator() 
        {
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
        }

    }
}
