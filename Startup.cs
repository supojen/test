using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace First
{
    public class Startup
    {
        private readonly ILogger<Startup> _logger;
        private readonly IConfiguration _config;
        public Startup(ILogger<Startup> logger, IConfiguration config)
        {
            _logger = logger ?? throw new  ArgumentNullException(nameof(logger));
            _config = config ?? throw new ArgumentNullException(nameof(config));
        }


        /* Here is the bussiness logic for our application */
        public async Task Run()
        {
            _logger.LogInformation("The main logic is starting now!");

            await Task.Delay(1000);

            _logger.LogInformation("The application stop now!");
        }
    }
}