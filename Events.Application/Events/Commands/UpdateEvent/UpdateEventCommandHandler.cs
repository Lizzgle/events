using AutoMapper;
using Events.Domain.Abstractions;
using Events.Domain.Entities;
using MediatR;

namespace Events.Application.Events.Commands.UpdateEvent
{
    public class UpdateEventCommandHandler : IRequestHandler<UpdateEventCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;

        public UpdateEventCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _eventRepository = unitOfWork.eventRepository;
            _mapper = mapper;
        }

        public async Task Handle(UpdateEventCommand request, CancellationToken token)
        {
            //Event eventToUpdate = _mapper.Map<Event>(request);

            Event? dbEvent = await _eventRepository.GetByIdAsync(request.Id);
            _mapper.Map(request, dbEvent);
            if (dbEvent is null)
                throw new KeyNotFoundException($"Event with id {request.Id} not found");

            await _eventRepository.UpdateAsync(dbEvent, token);
            await _unitOfWork.SaveChangesAsync(token);
        }
    }
}
