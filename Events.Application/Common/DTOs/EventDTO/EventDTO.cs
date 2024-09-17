﻿using Events.Application.Common.DTOs.ParticipantDTO;
using Events.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events.Application.Common.DTOs.EventDTO
{
    public class EventDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateTime { get; set; }
        public string Location { get; set; }
        public Category Category { get; set; }
        public int MaxParticipants { get; set; }
        public List<ParticipantDTOWithoutEvents> Participants { get; set; }
        public string UriImage { get; set; }
    }
}
