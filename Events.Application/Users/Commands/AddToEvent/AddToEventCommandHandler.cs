﻿using AutoMapper;
using Events.Domain.Abstractions;
using Events.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events.Application.Users.Commands.AddToEvent
{
    public class AddToEventCommandHandler : IRequestHandler<AddToEventCommand>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IParticipantRepository _participantRepository;

        public AddToEventCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _participantRepository = unitOfWork.Participants;
        }
        async Task IRequestHandler<AddToEventCommand>.Handle(AddToEventCommand request, CancellationToken cancellationToken)
        {
            Participant participant = _mapper.Map<Participant>(request);

            participant.Event = await _unitOfWork.Events.GetByIdAsync(request.EventId, cancellationToken);
            if (participant.Event is null)
                throw new InvalidOperationException("Event not found");

            participant.User = await _unitOfWork.Users.GetByIdAsync(request.UserId, cancellationToken);
            if (participant.User is null)
                throw new InvalidOperationException("User not found");

            if (participant.Event.Participants.Any(p => p.UserId == participant.UserId))
                throw new InvalidOperationException("User already participates in this event");

            await _participantRepository.AddUserToEvent(participant.UserId, participant.EventId, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
