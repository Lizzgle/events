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

namespace Events.Application.Events.Queries.GetEventById
{
    public class GetEventByIdQueryHandler : IRequestHandler<GetEventByIdQuery, EventDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetEventByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<EventDTO> Handle(GetEventByIdQuery request, CancellationToken cancellationToken)
        {
            Event? eventById = await _unitOfWork.Events.GetByIdAsync(request.Id, cancellationToken);

            if (eventById is null)
                throw new KeyNotFoundException($"Event with id {request.Id} not found");

            return _mapper.Map<EventDTO>(eventById);
        }
    }
}
