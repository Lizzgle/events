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
            _eventRepository = unitOfWork.Events;
            _mapper = mapper;
        }

        public async Task Handle(UpdateEventCommand request, CancellationToken cancellationToken)
        {
            Event eventToUpdate = _mapper.Map<Event>(request);

            //Event? dbEvent = await _eventRepository.GetByIdAsync(eventToUpdate.Id);
            
            //if (dbEvent is null)
            //    throw new KeyNotFoundException($"Event with id {eventToUpdate.Id} not found");

            //dbEvent.Description = request.Description;
            //dbEvent.Location = request.Location;
            //dbEvent.MaxParticipants = request.MaxParticipants;
            //dbEvent.DateTime = request.DateTime;
            //dbEvent.Category = request.Category;

            await _eventRepository.UpdateAsync(eventToUpdate, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
