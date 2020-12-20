using System;
using System.Reflection;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Serilog;
using System.Threading.Tasks;
using iCBM.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using iCBM.WebApi.Binders;
using Misio.Common.CQRS.Commands;
using Misio.Common.CQRS.Events;
using Misio.Common.CQRS.Events.Commands;
using Misio.Common.Logging.CQRS;
using Misio.EntityFrameworkCore;
using Misio.EntityFrameworkCore.CQRS;

namespace iCBM.WebApi
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            await WebHost
                .CreateDefaultBuilder(args)
                .UseSerilog((context, loggerConfiguration) =>
                {
                    loggerConfiguration.ReadFrom.Configuration(context.Configuration);

                    loggerConfiguration.Enrich.FromLogContext()
                        .Enrich.WithProperty("Environment", "Development")
                        .Enrich.WithProperty("Application", "iCBM")
                        .Enrich.WithProperty("Version", "0.0");
                })
                .ConfigureServices(services =>
                {
                    var configuration = services.BuildServiceProvider().GetService<IConfiguration>();

                    services
                        .AddCommandHandlers()
                        .AddEventHandlers()
                        .AddInMemoryCommandDispatcher()
                        .AddInMemoryEventDispatcher()
                        .AddEventDispatcherCommandDecorator()
                        .AddTransactionCommandDecorator()
                        .AddCommandHandlerLoggingDecorator()
                        .AddSqlContext<CbmContext>(configuration);

                    services.AddControllers(opts =>
                    {
                        opts.ModelBinderProviders.InsertBodyAndRouteBinding();
                    });

                    services.AddCors(options =>
                    {
                        options.AddPolicy(name: "allow-all",
                            builder =>
                            {
                                builder
                                    .AllowAnyHeader()
                                    .AllowAnyMethod()
                                    .AllowAnyOrigin();
                            });
                    });

                    services.AddMvc();
                })
                .Configure(app =>
                {
                    app.UseHttpsRedirection();
                    app.UseRouting();
                    app.UseAuthorization();
                    app.UseCors("allow-all");
                    app.UseEndpoints(endpoints =>
                    {
                        endpoints.MapControllers();
                    });

                })
                .Build()
                .MigrateDbContext<CbmContext>(null)
                .RunAsync();
        }
    }
}

