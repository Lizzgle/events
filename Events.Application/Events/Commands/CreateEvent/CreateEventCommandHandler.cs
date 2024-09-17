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
            _eventRepository = unitOfWork.Events;
            _mapper = mapper;
        }

        public async Task Handle(CreateEventCommand request, CancellationToken cancellationToken)
        {
            Event eventObj = _mapper.Map<Event>(request);

            Event? dbEvent = await _eventRepository.GetByIdAsync(eventObj.Id, cancellationToken);

            if (dbEvent is not null)
                throw new KeyNotFoundException($"Event with id {eventObj.Id} just found");

            await _eventRepository.CreateAsync(eventObj, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }

    }
}
