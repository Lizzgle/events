using AutoMapper;
using Events.Domain.Abstractions;
using Events.Domain.Entities;
using MediatR;

namespace Events.Application.Events.Commands.CreateEvent
{
    public class CreateEventCommandHandler : IRequestHandler<CreateEventCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;

        public CreateEventCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _eventRepository = unitOfWork.eventRepository;
            _mapper = mapper;
        }

        public async Task Handle(CreateEventCommand request, CancellationToken token)
        {
            Event eventObj = _mapper.Map<Event>(request);
            
            Event? dbEvent = await _eventRepository.GetByIdAsync(eventObj.Id, token);
            if (dbEvent is not null)
                throw new InvalidOperationException($"Event with id {eventObj.Id} already exists.");

            await _eventRepository.CreateAsync(eventObj, token);
            await _unitOfWork.SaveChangesAsync(token);
        }

    }
}
