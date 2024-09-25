using AutoMapper;
using Events.Application.Events.Commands.CreateEvent;
using Events.Domain.Entities;

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
