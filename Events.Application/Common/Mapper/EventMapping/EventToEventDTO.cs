using AutoMapper;
using Events.Application.Common.DTOs.EventDTO;
using Events.Application.Common.DTOs.ParticipantDTO;
using Events.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events.Application.Common.Mapper.EventMapping
{
    public class EventToEventDTO : Profile
    {
        public EventToEventDTO()
        {
            CreateMap<Event, EventDTO>();

            CreateMap<Participant, ParticipantDTOWithoutEvents>().ForMember(p => p.UserName, opt => opt.MapFrom(p => p.User.Name));
        }
    }
 }
