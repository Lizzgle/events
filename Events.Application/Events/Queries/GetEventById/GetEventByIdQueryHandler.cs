using AutoMapper;
using Events.Application.Common.DTOs;
using Events.Domain.Abstractions;
using Events.Domain.Entities;
using MediatR;

namespace Events.Application.Events.Queries.GetEventById
{
    public class GetEventByIdQueryHandler : IRequestHandler<GetEventByIdQuery, EventDTO>
    {
        private readonly IMapper _mapper;
        private readonly IEventRepository _eventRepository;
        public GetEventByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _eventRepository = unitOfWork.eventRepository;
            _mapper = mapper;
        }
        public async Task<EventDTO> Handle(GetEventByIdQuery request, CancellationToken token)
        {
            Event? eventById = await _eventRepository.GetByIdAsync(request.Id, token);

            if (eventById is null)
                throw new KeyNotFoundException($"Event with id {request.Id} not found");

            return _mapper.Map<EventDTO>(eventById);
        }
    }
}
