﻿using Events.Presentation.Options.Models;
using Microsoft.Extensions.Options;

namespace Events.Presentation.Options.Setups
{
    public class WWWRootOptionsSetup : IConfigureOptions<WWWRootOptions>
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IConfiguration _configuration;

        public WWWRootOptionsSetup(IWebHostEnvironment webHostEnvironment, IConfiguration configuration)
        {
            _webHostEnvironment = webHostEnvironment;
            _configuration = configuration;
        }

        public void Configure(WWWRootOptions options)
        {
            options.WebRootPath = _webHostEnvironment.WebRootPath;

            options.Host = _configuration["ApplicationUrl"]!;
        }
    }
}
