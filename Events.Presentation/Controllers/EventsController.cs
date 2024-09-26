using Events.Application.Common.DTOs;
using Events.Application.Events.Commands.AddImage;
using Events.Application.Events.Commands.CreateEvent;
using Events.Application.Events.Commands.DeleteEvent;
using Events.Application.Events.Commands.UpdateEvent;
using Events.Application.Events.Queries.GetAllEvents;
using Events.Application.Events.Queries.GetEventById;
using Events.Application.Events.Queries.GetEventByName;
using Events.Application.Events.Queries.GetFilteredEvent;
using Events.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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
        public async Task<IActionResult> GetEventsAsync(CancellationToken token, 
            [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 2)
        {
            var events = await _mediator.Send(new GetAllEventsQuery() { PageNumber = pageNumber, PageSize = pageSize}, token);
            return Ok(events);
        }

        // GET: api/<EventsControllerByFilters>
        [HttpGet("searchByFilters")]
        public async Task<IActionResult> GetEventsByFiltersAsync([FromQuery] DateTime? date,
            [FromQuery] string? category,
            [FromQuery] string? location,
            CancellationToken token, [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 2)
        {
            var query = new GetFilteredEventQuery()
            {
                Date = date,
                CategoryName = category,
                Location = location,
                PageNumber = pageNumber,
                PageSize = pageSize
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

        // GET api/<EventsController>/5
        [HttpGet("name/{name}")]
        public async Task<IActionResult> GetEventByNameAsync([FromRoute] string name, CancellationToken token)
        {
            EventDTO eventdto = await _mediator.Send(new GetEventByNameQuery() { Name = name }, token);
            return Ok(eventdto);
        }

        // POST api/<EventsController>
        [HttpPost]
        [Authorize(Policy = PolicyTypes.AdminPolicy)]
        public async Task<IActionResult> CreateEventAsync([FromBody] CreateEventCommand createEventCommand, CancellationToken token)
        {
            await _mediator.Send(createEventCommand, token);
            return Ok();
        }

        // PUT api/<EventsController>/5
        [HttpPut("{id}")]
        [Authorize(Policy = PolicyTypes.AdminPolicy)]
        public async Task<IActionResult> UpdateEventAsync( 
            [FromBody] UpdateEventCommand updateEventCommand, CancellationToken token)
        {
            await _mediator.Send(updateEventCommand, token);
            return Ok();
        }

        // DELETE api/<EventsController>/5
        [HttpDelete("{id}")]
        [Authorize(Policy = PolicyTypes.AdminPolicy)]
        public async Task<IActionResult> DeleteEventAsync([FromRoute] Guid id, CancellationToken token)
        {
            await _mediator.Send(new DeleteEventCommand() { Id = id }, token);
            return Ok();
        }

        [HttpPost("image/{id:guid}")]
        [Authorize(Policy = PolicyTypes.AdminPolicy)]
        public async Task<IActionResult> AddImageAsync([FromRoute] Guid id, IFormFile formFile, CancellationToken token)
        {
            var query = new AddImageCommand()
            {
                Id = id,
                FileName = formFile.FileName,
                ImageStream = formFile.OpenReadStream()
            };
            await _mediator.Send(query, token);

            return Ok();
        }
    }
}
