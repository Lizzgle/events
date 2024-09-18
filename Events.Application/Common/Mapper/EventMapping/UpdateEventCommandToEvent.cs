using AutoMapper;
using Events.Application.Events.Commands.UpdateEvent;
using Events.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events.Application.Common.Mapper.EventMapping
{
    public class UpdateEventCommandToEvent : Profile
    {
        public UpdateEventCommandToEvent()
        {
            CreateMap<UpdateEventCommand, Event>()
            .ForMember(dest => dest.Id, opt => opt.Ignore());
        }
    }
}
