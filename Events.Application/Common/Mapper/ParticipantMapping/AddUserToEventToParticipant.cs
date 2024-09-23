using AutoMapper;
using Events.Application.Participants.Commands.AddUserToEvent;
using Events.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
