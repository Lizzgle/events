using AutoMapper;
using Events.Application.Events.Commands.CreateEvent;
using Events.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events.Application.Common.Mapper.EventMapping
{
    public class CreateEventCommandToEvent : Profile
    {
        public CreateEventCommandToEvent() 
        {
            CreateMap<CreateEventCommand, Event>();
        }


    }
}
