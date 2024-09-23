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
        private readonly IParticipantRepository _participantRepository;

        public RemoveUserFromEventCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _participantRepository = unitOfWork.Participants;
        }
        public async Task Handle(RemoveUserFromEventCommand request, CancellationToken cancellationToken)
        {
            Participant? participant = await _participantRepository.GetByUserAndByEventAsync(request.UserId, request.EventId, cancellationToken);
            if (participant is null)
                throw new InvalidOperationException("Participant not found");

            await _participantRepository.DeleteAsync(participant, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
