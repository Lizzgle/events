using AutoMapper;
using Events.Application.Events.Commands.CreateEvent;
using Events.Domain.Abstractions;
using Events.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events.Application.Events.Commands.DeleteEvent
{
    public class DeleteEventCommandHandler : IRequestHandler<DeleteEventCommand>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEventRepository _eventRepository;

        public DeleteEventCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _eventRepository = unitOfWork.Events;
        }

        public async Task Handle(DeleteEventCommand request, CancellationToken cancellationToken)
        {

            Event? dbEvent = await _eventRepository.GetByIdAsync(request.Id);
            if (dbEvent is null)
            {
                throw new InvalidOperationException("Event not found.");
            }

            await _eventRepository.DeleteAsync(dbEvent, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
