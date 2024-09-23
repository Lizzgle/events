using AutoMapper;
using Events.Application.Common.DTOs.ParticipantDTO;
using Events.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events.Application.Common.Mapper.ParticipantMapping
{
    public class ParticipantProfile : Profile
    { 
        public ParticipantProfile() 
        {
            CreateMap<Participant, ParticipantDTOWithoutEventsAndUsers>();
        }

    }
}
