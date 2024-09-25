using AutoMapper;
using Events.Application.Common.DTOs;
using Events.Domain.Entities;

namespace Events.Application.Common.Mapper.ParticipantMapping
{
    public class ParticipantToParticipantDTO : Profile
    { 
        public ParticipantToParticipantDTO() 
        {
            CreateMap<Participant, ParticipantDTO>().ForMember(p => p.UserName, opt => opt.MapFrom(p => p.User.Name));
        }

    }
}
