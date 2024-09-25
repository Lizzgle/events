using FluentValidation;

namespace Events.Application.Events.Commands.AddImage
{
    public class AddImageCommandValidator : AbstractValidator<AddImageCommand>
    {
        public AddImageCommandValidator()
        {
            RuleFor(b => b.Id).NotEmpty();
        }
    }
}
