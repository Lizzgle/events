using Microsoft.AspNetCore.Mvc;
using Events.Domain.Entities;
using MediatR;
using Events.Application.Participants.Commands.AddUserToEvent;
using Events.Application.Participants.Commands.RemoveUserFromEvent;
using Events.Application.Events.Queries.GetEventByIdWithParticipants;
using Microsoft.AspNetCore.Authorization;

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
        [Authorize(Policy = PolicyTypes.ClientPolicy)]
        public async Task<ActionResult<Participant>> AddUserToEventAsync([FromRoute] Guid userId, Guid eventId)
        {
            await _mediator.Send(new AddUserToEventCommand() { UserId = userId, EventId = eventId});
            return Ok();
        }

        [HttpDelete("delete/{userId}/FromEvent/{eventId}")]
        [Authorize(Policy = PolicyTypes.ClientPolicy)]
        public async Task<ActionResult<Participant>> RemoveUserToEventAsync([FromRoute] Guid userId, Guid eventId)
        {
            await _mediator.Send(new RemoveUserFromEventCommand() { UserId = userId, EventId = eventId });
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
