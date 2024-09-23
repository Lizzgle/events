using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Events.Domain.Entities;
using Events.Infrastructure;
using MediatR;
using Events.Application.Participants.Commands.AddUserToEvent;
using Events.Application.Participants.Commands.RemoveUserFromEvent;
using Events.Application.Events.Queries.GetEventByIdWithParticipants;

namespace Events.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParticipantsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ParticipantsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("add/{userId}/toEvent/{eventId}")]
        public async Task<ActionResult<Participant>> AddUserToEventAsync([FromRoute] Guid userId, Guid eventId)
        {
            await _mediator.Send(new AddUserToEventCommand() { UserId = userId, EventId = eventId});
            return Ok();
        }

        [HttpDelete("delete/{userId}/FromEvent/{eventId}")]
        public async Task<ActionResult<Participant>> RemoveUserToEventAsync([FromRoute] Guid userId, Guid eventId)
        {
            await _mediator.Send(new RemoveUserFromEventCommand() { UserId = userId, EventId = eventId });
            return Ok();
        }

        [HttpGet("{eventId}")]
        public async Task<ActionResult<IEnumerable<Participant>>> GetParticipantsByEventIdAsync([FromRoute] Guid eventId)
        {
            var participants = await _mediator.Send(new GetParticipantsByEventIdQuery() { Id = eventId });
            return Ok(participants);
        }
    }
}
