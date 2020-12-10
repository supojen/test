using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Plantsist.Data;
using Serilog;
using Microsoft.EntityFrameworkCore;
using Plantsist.Service;


// DI, Serilog, Settings


namespace Plantsist
{
    class Program
    {
        static async Task Main(string[] args)
        {
            
            //  Processing 1 - 
            //      Configure the appsettings.json file
            var builder = new ConfigurationBuilder();
            BuildConfig(builder);

            // Processing 2 - 
            //      Configure the logging system
            Log.Logger = new LoggerConfiguration()
                             .ReadFrom.Configuration(builder.Build())
                             .Enrich.FromLogContext()
                             .WriteTo.Console()
                             .CreateLogger();

            // Processing 3 - 
            //      Create an host system for doing dependency injection
            var host = Host.CreateDefaultBuilder()
                        .ConfigureServices((context, services) =>
                        {
                            // Dependecy Injection Here
                            services.AddSingleton<Startup>();

                            var connectionString = context.Configuration.GetValue<string>("DbConnectionString");
                            services.AddDbContext<AppDbContext>(opts => 
                                opts.UseSqlServer(connectionString)
                            );

                            services.AddScoped<ITest,Test>();
                        })
                        .Build();

            // Processing 4 - 
            //      Run the Bussiness Logic
            var startup = ActivatorUtilities.CreateInstance<Startup>(host.Services);
            await startup.Run();
            
        }


        /* This method is about configuration the json file for us to use */
        static void BuildConfig(IConfigurationBuilder builder)
        {
            /* 
                optional means adding the appsettings.json is not optional, it is required.
                reloadOnChange means when ever the appsettings.json change, reload the json file.
             */
            builder.SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                   .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMNET") ?? "Production"}.json", optional: true)
                   .AddEnvironmentVariables();
        }
    }

}
