using AutoMapper;
using Events.Application.Common.DTOs.EventDTO;
using Events.Application.Common.DTOs.ParticipantDTO;
using Events.Domain.Abstractions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events.Application.Events.Queries.GetEventByIdWithParticipants
{
    public class GetParticipantsByEventIdQueryHandler : IRequestHandler<GetParticipantsByEventIdQuery, IEnumerable<ParticipantDTOWithoutEventsAndUsers>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IParticipantRepository _participantRepository;

        public GetParticipantsByEventIdQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _participantRepository = unitOfWork.Participants;
        }

        async Task<IEnumerable<ParticipantDTOWithoutEventsAndUsers>> IRequestHandler<GetParticipantsByEventIdQuery, IEnumerable<ParticipantDTOWithoutEventsAndUsers>>.Handle(GetParticipantsByEventIdQuery request, CancellationToken cancellationToken)
        {
            var eventById = await _unitOfWork.Events.GetByIdAsync(request.Id);

            if (eventById is null)
                throw new KeyNotFoundException($"Event with id {request.Id} not found");

            var participants = await _participantRepository.GetByEventIdAsync(request.Id);
            return _mapper.Map<IEnumerable<ParticipantDTOWithoutEventsAndUsers>>(participants);
        }
    }
}
