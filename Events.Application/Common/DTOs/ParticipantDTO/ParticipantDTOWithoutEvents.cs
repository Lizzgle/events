using AutoMapper;
using Events.Application.Common.DTOs.UserDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events.Application.Common.DTOs.ParticipantDTO
{
    public class ParticipantDTOWithoutEvents
    {
        public Guid Id { get; set; }
        //public ShortUserDTO User { get; set; }
        public string UserName { get; set; }
        public DateTime DateOfRegistration { get; set; }
    }
}
