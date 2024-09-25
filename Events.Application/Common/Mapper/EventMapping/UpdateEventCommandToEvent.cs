using AutoMapper;
using Events.Application.Events.Commands.UpdateEvent;
using Events.Domain.Entities;

namespace Events.Application.Common.Mapper.EventMapping
{
    public class UpdateEventCommandToEvent : Profile
    {
        public UpdateEventCommandToEvent()
        {
            CreateMap<UpdateEventCommand, Event>();
        }
    }
}
