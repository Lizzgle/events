namespace Events.Application.Common.Services
{
    public interface IImageService
    {
        public Task<string> SaveImageAsync(Stream source, string fileName, string? prevImageUrl, 
            CancellationToken token = default);
    }
}
