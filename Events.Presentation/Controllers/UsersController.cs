using Events.Application.Users.Commands.Login;
using Events.Application.Users.Commands.Registration;
using Events.Application.Users.Queries.GetUserEvents;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Events.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("registration")]
        public async Task<IActionResult> RegistrationAsync([FromBody] RegistrationCommand registrationCommand, 
            CancellationToken token = default)
        {
            RegistrationCommandResponse response = await _mediator.Send(registrationCommand, token);
            return Ok(response);
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginCommand loginCommand, CancellationToken token = default)
        {
            LoginCommandResponse response = await _mediator.Send(loginCommand, token);
            return Ok(response);
        }

        [HttpGet("{userId:guid}/events")]
        [Authorize(Policy = PolicyTypes.ClientPolicy)]
        public async Task<IActionResult> GetUserEventsAsync([FromRoute] Guid userId, CancellationToken token, 
            [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 2)
        {
            var query = new GetUserEventsQuery()
            {
                Id = userId,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
            var events = await _mediator.Send(query, token);
            return Ok(events);
        }
    }
}
