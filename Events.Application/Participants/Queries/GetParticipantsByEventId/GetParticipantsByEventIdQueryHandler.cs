using AutoMapper;
using Events.Application.Common.DTOs;
using Events.Application.Common.Models;
using Events.Domain.Abstractions;
using MediatR;

namespace Events.Application.Events.Queries.GetEventByIdWithParticipants
{
    public class GetParticipantsByEventIdQueryHandler : IRequestHandler<GetParticipantsByEventIdQuery, PaginatedResult<ParticipantDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IParticipantRepository _participantRepository;
        private readonly IEventRepository _eventRepository;

        public GetParticipantsByEventIdQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _participantRepository = unitOfWork.participantRepository;
            _eventRepository = unitOfWork.eventRepository;
        }

        public async Task<PaginatedResult<ParticipantDTO>> Handle(GetParticipantsByEventIdQuery request, CancellationToken token)
        {
            var eventById = await _eventRepository.GetByIdAsync(request.Id);

            if (eventById is null)
                throw new KeyNotFoundException($"Event with id {request.Id} not found");

            var query = await _participantRepository.GetByEventIdAsync(request.Id);
            int count = query.Count();
            var participants = query.Skip((request.PageNumber - 1) * request.PageSize).Take(request.PageSize).ToList();
            
            return new()
            {
                Items = _mapper.Map<IEnumerable<ParticipantDTO>>(participants),
                CurrentPage = request.PageNumber,
                PageSize = request.PageSize,
                TotalPages = (int)Math.Ceiling(count / (double)request.PageSize)
            };
        }
    }
}
