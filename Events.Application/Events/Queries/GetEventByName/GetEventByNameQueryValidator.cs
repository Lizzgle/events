using FluentValidation;

namespace Events.Application.Events.Queries.GetEventByName
{
    public class GetEventByNameQueryValidator : AbstractValidator<GetEventByNameQuery>
    {
        public GetEventByNameQueryValidator() 
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
        }

    }
}
