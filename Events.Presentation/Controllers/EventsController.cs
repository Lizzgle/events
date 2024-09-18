using Events.Application.Common.DTOs.EventDTO;
using Events.Application.Events.Commands.CreateEvent;
using Events.Application.Events.Commands.DeleteEvent;
using Events.Application.Events.Commands.UpdateEvent;
using Events.Application.Events.Queries.GetAllEvents;
using Events.Application.Events.Queries.GetEventById;
using Events.Application.Events.Queries.GetEventsByCriteria;
using Events.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Events.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public EventsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: api/<EventsController>
        [HttpGet]
        public async Task<IActionResult> GetEventsAsync(CancellationToken token)
        {
            var events = await _mediator.Send(new GetAllEventsQuery(), token);
            return Ok(events);
        }

        // GET: api/<EventsControllerByFilters>
        [HttpGet("search")]
        public async Task<IActionResult> GetEventsByFiltersAsync([FromQuery] DateTime? date,
            [FromQuery] Category? category,
            [FromQuery] string? location,
            CancellationToken token)
        {
            var query = new GetEventsByCriteria
            {
                Date = date,
                Category = category,
                Location = location
            };
            var events = await _mediator.Send(query, token);
            return Ok(events);
        }

        // GET api/<EventsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEventByIdAsync([FromRoute] Guid id, CancellationToken token)
        {
            EventDTO eventdto = await _mediator.Send(new GetEventByIdQuery() { Id = id }, token);

            return Ok(eventdto);
        }

        // POST api/<EventsController>
        [HttpPost]
        public async Task<IActionResult> CreateEventAsync([FromBody] CreateEventCommand createEventCommand, CancellationToken token)
        {
            await _mediator.Send(createEventCommand, token);
            return Ok();
        }

        // PUT api/<EventsController>/5
        [HttpPut("{id}")]

        public async Task<IActionResult> UpdateEventAsync( 
            [FromBody] UpdateEventCommand updateEventCommand, CancellationToken token)
        {
            await _mediator.Send(updateEventCommand, token);
            return Ok();
        }

        // DELETE api/<EventsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEventAsync([FromRoute] Guid id, CancellationToken token)
        {
            await _mediator.Send(new DeleteEventCommand() { Id = id }, token);
            return Ok();
        }
    }
}
