using AutoMapper;
using Events.Application.Common.DTOs.EventDTO;
using Events.Domain.Abstractions;
using Events.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events.Application.Events.Queries.GetEventByName
{
    public class GetEventByNameQueryHandler : IRequestHandler<GetEventByNameQuery, EventDTO>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEventRepository _eventRepository;

        public GetEventByNameQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _eventRepository = unitOfWork.Events;
        }

        async Task<EventDTO> IRequestHandler<GetEventByNameQuery, EventDTO>.Handle(GetEventByNameQuery request, CancellationToken cancellationToken)
        {
            Event? eventByName = await _eventRepository.GetEventByName(request.Name, cancellationToken);
            
            if (eventByName is null)
                throw new KeyNotFoundException($"Event with name {request.Name} not found");

            return _mapper.Map<EventDTO>(eventByName);
        }
    }
}
