using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events.Application.Common.Services
{
    public interface IImageService
    {
        public Task<string> SaveImageAsync(Stream source, string fileName, string? prevImageUrl, 
            CancellationToken token = default);
    }
}
