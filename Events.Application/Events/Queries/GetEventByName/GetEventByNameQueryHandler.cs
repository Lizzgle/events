using AutoMapper;
using Events.Application.Common.DTOs;
using Events.Domain.Abstractions;
using Events.Domain.Entities;
using MediatR;

namespace Events.Application.Events.Queries.GetEventByName
{
    public class GetEventByNameQueryHandler : IRequestHandler<GetEventByNameQuery, EventDTO>
    {
        private readonly IMapper _mapper;
        private readonly IEventRepository _eventRepository;

        public GetEventByNameQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _eventRepository = unitOfWork.eventRepository;
        }

        async Task<EventDTO> IRequestHandler<GetEventByNameQuery, EventDTO>.Handle(GetEventByNameQuery request, CancellationToken token)
        {
            Event? eventByName = await _eventRepository.GetEventByNameAsync(request.Name, token);
            
            if (eventByName is null)
                throw new KeyNotFoundException($"Event with name {request.Name} not found");

            return _mapper.Map<EventDTO>(eventByName);
        }
    }
}
