using AutoMapper;
using Events.Domain.Abstractions;
using Events.Domain.Entities;
using MediatR;

namespace Events.Application.Participants.Commands.RemoveUserFromEvent
{
    public class RemoveUserFromEventCommandHandler : IRequestHandler<RemoveUserFromEventCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IParticipantRepository _participantRepository;

        public RemoveUserFromEventCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _participantRepository = unitOfWork.participantRepository;
        }
        public async Task Handle(RemoveUserFromEventCommand request, CancellationToken token)
        {
            Participant? participant = await _participantRepository.GetByUserAndByEventAsync(request.UserId, request.EventId, 
                token);
            if (participant is null)
                throw new InvalidOperationException("Participant not found");

            await _participantRepository.DeleteAsync(participant, token);
            await _unitOfWork.SaveChangesAsync(token);
        }
    }
}
