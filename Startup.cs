using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Plantsist.Data;
using Microsoft.EntityFrameworkCore;
using Plantsist.Service;

namespace Plantsist
{
    public class Startup
    {
        private readonly ILogger<Startup> _logger;
        private readonly IConfiguration _config;
        private readonly ITest _test;

        public Startup(ILogger<Startup> logger, IConfiguration config, ITest test)
        {
            _logger = logger ?? throw new  ArgumentNullException(nameof(logger));
            _config = config ?? throw new ArgumentNullException(nameof(config));
            _test = test ?? throw new ArgumentNullException(nameof(test));
        }


        /* Here is the bussiness logic for our application */
        public async Task Run()
        {
            _logger.LogInformation("The main logic is starting now!");

            _test.Add();

            await Task.Delay(1000);

            System.Console.WriteLine("Hello World.");
            System.Console.WriteLine("Hi Po!");

            _logger.LogInformation("The application stop now!");
        }
    }
}