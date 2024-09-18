﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events.Application.Events.Queries.GetEventById
{
    public class GetEventByIdQueryValidator : AbstractValidator<GetEventByIdQuery>
    {
        public GetEventByIdQueryValidator() 
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
