using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events.Application.Events.Queries.GetAllEvents
{
    public class GetAllEventsQueryValidator : AbstractValidator<GetAllEventsQuery>
    {
        public GetAllEventsQueryValidator() 
        {
            RuleFor(x => x.PageNumber).GreaterThan(0);
            RuleFor(x => x.PageSize).GreaterThan(0);
        }

    }
}
