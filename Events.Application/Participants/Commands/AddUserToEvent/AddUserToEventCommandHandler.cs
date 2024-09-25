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
        private readonly IEventRepository _eventRepository;
        private readonly IUserRepository _userRepository;

        public AddUserToEventCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _participantRepository = unitOfWork.participantRepository;
            _eventRepository = unitOfWork.eventRepository;
            _userRepository = unitOfWork.userRepository;
        }
        public async Task Handle(AddUserToEventCommand request, CancellationToken token)
        {
            Participant participant = _mapper.Map<Participant>(request);

            Event? eventdb = participant.Event;
            User? userdb = participant.User;

            eventdb = await _eventRepository.GetByIdAsync(request.EventId, token);
            if (eventdb is null)
                throw new InvalidOperationException("Event not found");
            
            userdb = await _userRepository.GetByIdAsync(request.UserId, token);
            if (userdb is null)
                throw new InvalidOperationException("User not found");

            if (eventdb.Participants.Any(p => p.UserId == userdb.Id))
                throw new InvalidOperationException("User already participates in this event");

            int count = await _eventRepository.CountOfParticipantsAsync(eventdb.Id, token);
            if (count >= eventdb.MaxParticipants)
                throw new InvalidOperationException("Event is full");

            await _participantRepository.CreateAsync(participant);
            await _unitOfWork.SaveChangesAsync(token);
        }
    }
}
