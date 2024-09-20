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
    public class GetEventByIdWithParticipantsQueryHandler : IRequestHandler<GetEventByIdWithParticipantsQuery, EventDTO>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEventRepository _eventRepository;

        public GetEventByIdWithParticipantsQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _eventRepository = unitOfWork.Events;
        }
        public async Task<EventDTO> Handle(GetEventByIdWithParticipantsQuery request, CancellationToken token)
        {
            var eventById = await _eventRepository.GetEventByIdWithParticipants(request.Id, token);

            if (eventById is null)
                throw new KeyNotFoundException($"Event with id {request.Id} not found");

            return _mapper.Map<EventDTO>(eventById);
        }
    }
}
