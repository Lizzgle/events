using AutoMapper;
using Events.Application.Common.DTOs;
using Events.Domain.Entities;

namespace Events.Application.Common.Mapper.EventMapping
{
    public class EventToEventDTO : Profile
    {
        public EventToEventDTO()
        {
            CreateMap<Event, EventDTO>();
        }
    }
 }
