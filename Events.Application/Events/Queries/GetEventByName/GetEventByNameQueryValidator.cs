using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
