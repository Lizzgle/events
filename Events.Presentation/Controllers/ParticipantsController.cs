using Microsoft.AspNetCore.Mvc;
using Events.Domain.Entities;
using MediatR;
using Events.Application.Participants.Commands.AddUserToEvent;
using Events.Application.Participants.Commands.RemoveUserFromEvent;
using Events.Application.Events.Queries.GetEventByIdWithParticipants;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

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

        [HttpPost("add/toEvent/{eventId}")]
        [Authorize(Policy = PolicyTypes.ClientPolicy)]
        public async Task<ActionResult<Participant>> AddUserToEventAsync([FromRoute] Guid eventId)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            await _mediator.Send(new AddUserToEventCommand() { UserId = Guid.Parse(userId), EventId = eventId});
            return Ok();
        }

        [HttpDelete("delete/FromEvent/{eventId}")]
        [Authorize(Policy = PolicyTypes.ClientPolicy)]
        public async Task<ActionResult<Participant>> RemoveUserToEventAsync([FromRoute] Guid eventId)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            await _mediator.Send(new RemoveUserFromEventCommand() { UserId = Guid.Parse(userId), EventId = eventId });
            return Ok();
        }

        [HttpGet("{eventId}")]
        [Authorize(Policy = PolicyTypes.AdminPolicy)]
        public async Task<ActionResult<IEnumerable<Participant>>> GetParticipantsByEventIdAsync([FromRoute] Guid eventId, 
            CancellationToken token, [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 2)
        {
            var query = new GetParticipantsByEventIdQuery() 
            { 
                Id = eventId, 
                PageNumber = pageNumber, 
                PageSize = pageSize 
            };
            var participants = await _mediator.Send(query, token);
            return Ok(participants);
        }
    }
}
