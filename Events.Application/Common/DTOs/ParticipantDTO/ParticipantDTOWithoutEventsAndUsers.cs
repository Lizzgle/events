using Events.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events.Application.Common.DTOs.ParticipantDTO
{
    public class ParticipantDTOWithoutEventsAndUsers
    {
        public Guid Id { get; set; }
        public DateTime DateOfRegistration { get; set; }
    }
}
