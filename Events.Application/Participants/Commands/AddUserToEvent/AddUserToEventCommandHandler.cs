using AutoMapper;
using Events.Domain.Abstractions;
using Events.Domain.Entities;
using MediatR;


namespace Events.Application.Participants.Commands.AddUserToEvent
{
    public class AddUserToEventCommandHandler : IRequestHandler<AddUserToEventCommand>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IParticipantRepository _participantRepository;

        public AddUserToEventCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _participantRepository = unitOfWork.Participants;
        }
        public async Task Handle(AddUserToEventCommand request, CancellationToken cancellationToken)
        {
            Participant participant = _mapper.Map<Participant>(request);

            Event eventdb = participant.Event;
            User userdb = participant.User;

            eventdb = await _unitOfWork.Events.GetByIdAsync(request.EventId, cancellationToken);
            if (eventdb is null)
                throw new InvalidOperationException("Event not found");

            userdb = await _unitOfWork.Users.GetByIdAsync(request.UserId, cancellationToken);
            if (userdb is null)
                throw new InvalidOperationException("User not found");

            if (eventdb.Participants.Any(p => p.UserId == userdb.Id))
                throw new InvalidOperationException("User already participates in this event");


            int count = await _unitOfWork.Events.CountOfParticipants(eventdb.Id, cancellationToken);
            if (count == eventdb.MaxParticipants)
                throw new InvalidOperationException("Event is full");

            await _participantRepository.CreateAsync(participant);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
