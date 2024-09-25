using Events.Domain.Abstractions;
using Events.Domain.Entities;
using MediatR;

namespace Events.Application.Events.Commands.DeleteEvent
{
    public class DeleteEventCommandHandler : IRequestHandler<DeleteEventCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEventRepository _eventRepository;

        public DeleteEventCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _eventRepository = unitOfWork.eventRepository;
        }

        public async Task Handle(DeleteEventCommand request, CancellationToken token)
        {

            Event? dbEvent = await _eventRepository.GetByIdAsync(request.Id);
            if (dbEvent is null)
            {
                throw new InvalidOperationException("Event not found.");
            }

            await _eventRepository.DeleteAsync(dbEvent, token);
            await _unitOfWork.SaveChangesAsync(token);
        }
    }
}
