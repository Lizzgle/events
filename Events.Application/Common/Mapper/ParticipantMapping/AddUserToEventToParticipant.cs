using AutoMapper;
using Events.Application.Participants.Commands.AddUserToEvent;
using Events.Domain.Entities;

namespace Events.Application.Common.Mapper.ParticipantMapping
{
    public class AddUserToEventToParticipant : Profile
    {
        public AddUserToEventToParticipant()
        {
            CreateMap<AddUserToEventCommand, Participant>();
        }

    }

}
