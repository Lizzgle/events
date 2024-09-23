using AutoMapper;
using Events.Domain.Abstractions;
using Events.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events.Application.Participants.Commands.RemoveUserFromEvent
{
    public class RemoveUserFromEventCommandHandler : IRequestHandler<RemoveUserFromEventCommand>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEventRepository _eventRepository;

        public RemoveUserFromEventCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _eventRepository = unitOfWork.Events;
        }
        public async Task Handle(RemoveUserFromEventCommand request, CancellationToken cancellationToken)
        {
            Participant participant = _mapper.Map<Participant>(request);

            participant.Event = _eventRepository.GetByIdAsync(request.EventId, cancellationToken).Result;
            if (participant.Event is null)
                throw new InvalidOperationException("Event not found");

            await _unitOfWork.Participants.RemoveUserFromEvent(request.UserId, request.EventId, cancellationToken);
        }
    }
}
