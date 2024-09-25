using Events.Application.Common.Services;
using Events.Domain.Abstractions;
using Events.Domain.Entities;
using MediatR;

namespace Events.Application.Events.Commands.AddImage
{
    public class AddImageCommandHandler : IRequestHandler<AddImageCommand>
    {
        private readonly IEventRepository _eventRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IImageService _imageService;

        public AddImageCommandHandler(IUnitOfWork unitOfWork,IImageService imageService)
        {
            _unitOfWork = unitOfWork;
            _eventRepository = unitOfWork.eventRepository;
            _imageService = imageService;
        }

        public async Task Handle(AddImageCommand request, CancellationToken token)
        {
            Event? dbEvent = await _eventRepository.GetByIdAsync(request.Id);

            if (dbEvent is null)
                throw new KeyNotFoundException($"Event with id {request.Id} not found");

            string imagePath = await _imageService.SaveImageAsync(request.ImageStream, request.FileName, dbEvent.UriImage, token);

            dbEvent.UriImage = imagePath;

            await _eventRepository.UpdateAsync(dbEvent, token);
            await _unitOfWork.SaveChangesAsync(token);
        }
    }
}
