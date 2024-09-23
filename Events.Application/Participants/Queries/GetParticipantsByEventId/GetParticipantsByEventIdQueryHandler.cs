using AutoMapper;
using Events.Application.Common;
using Events.Application.Common.DTOs.EventDTO;
using Events.Application.Common.DTOs.ParticipantDTO;
using Events.Domain.Abstractions;
using Events.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events.Application.Events.Queries.GetEventByIdWithParticipants
{
    public class GetParticipantsByEventIdQueryHandler : IRequestHandler<GetParticipantsByEventIdQuery, PaginatedResult<ParticipantDTOWithoutEvents>>
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

        public async Task<PaginatedResult<ParticipantDTOWithoutEvents>> Handle(GetParticipantsByEventIdQuery request, CancellationToken cancellationToken)
        {
            var eventById = await _unitOfWork.Events.GetByIdAsync(request.Id);

            if (eventById is null)
                throw new KeyNotFoundException($"Event with id {request.Id} not found");

            var query = await _participantRepository.GetByEventIdAsync(request.Id);
            int count = query.Count();
            var participants = query.Skip((request.PageNumber - 1) * request.PageSize).Take(request.PageSize).ToList();
            return new()
            {
                Items = _mapper.Map<IEnumerable<ParticipantDTOWithoutEvents>>(participants),
                CurrentPage = request.PageNumber,
                PageSize = request.PageSize,
                TotalPages = (int)Math.Ceiling(count / (double)request.PageSize)
            };
        }
    }
}
