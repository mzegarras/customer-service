using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon.SimpleNotificationService;
using Clientes.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Clientes.Microservice
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<ClienteService, ClienteServiceImpl>();
            services.AddScoped<NotificationService, NotificationServiceImpl>();
            services.AddScoped<IAmazonSimpleNotificationService, AmazonSimpleNotificationServiceClient>();
            
            
            //services.AddLogging(configure => configure.AddConsole());
            //services.AddLogging(configure => configure.AddDebug());
            //services.AddSingleton<ClienteService,ClienteServiceImpl>();


            var serviceProvider = new ServiceCollection()
                      .AddLogging(configure => configure.AddConsole())
                      .BuildServiceProvider();

             //configure console logging
            serviceProvider
                    .GetService<ILoggerFactory>()
                    .AddConsole(LogLevel.Debug);

            var logger = serviceProvider.GetService<ILoggerFactory>()
                        .CreateLogger<Program>();
            
            logger.LogInformation("Starting application");

            services.AddMvc();

            logger.LogInformation("All done!");
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHealthAllEndpoints();
            app.UseMvc();
        }
    }
}
