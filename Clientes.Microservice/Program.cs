using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
//using log4net.Config;
using System.Reflection;
using App.Metrics.AspNetCore.Health;
using App.Metrics.Health;



namespace Clientes.Microservice
{
    public class Program
    {
        public static void Main(string[] args)
        {

            //var logRepository = log4net.LogManager.GetRepository(Assembly.GetEntryAssembly());
            //XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));

            BuildWebHost(args).Run();
            
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureHealthWithDefaults(
                builder =>
                {
                    
                    //builder.HealthChecks.AddCheck("DatabaseConnected", () => new ValueTask<HealthCheckResult>(HealthCheckResult.Healthy("Database Connection OK")));
                    //builder.HealthChecks.AddProcessPrivateMemorySizeCheck("Private Memory Size", 100);
                    //builder.HealthChecks.AddProcessVirtualMemorySizeCheck("Virtual Memory Size", 200);
                    //builder.HealthChecks.AddProcessPhysicalMemoryCheck("Working Set", 300);
                    //builder.HealthChecks.AddPingCheck("google ping", "google.com", TimeSpan.FromSeconds(10));
                    //builder.HealthChecks.AddHttpGetCheck("github", new Uri("https://github.com/"), TimeSpan.FromSeconds(10));
                })
                /*.ConfigureAppHealthHostingConfiguration(options =>
                {
                    options.HealthEndpoint = "/my-health";
                    options.HealthEndpointPort = 1111;
                    options.PingEndpoint = "/my-ping";
                    options.PingEndpointPort = 2222;
                })*/
                .UseHealth()
                .UseStartup<Startup>()
                .Build();


    }
}
