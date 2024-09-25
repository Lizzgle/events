using FluentValidation;

namespace Events.Application.Users.Commands.Registration
{
    public class RegistrationCommandValidator : AbstractValidator<RegistrationCommand>
    {
        public RegistrationCommandValidator() 
        {
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Surname).NotEmpty();
            RuleFor(x => x.DateOfBirth).NotEmpty().LessThan(DateTime.UtcNow.Date);
        }

    }
}
