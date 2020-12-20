using System.Collections.Generic;
using iCBM.Infrastructure;
using iCBM.WebApi.Binders;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Misio.Common.CQRS.Commands;
using Misio.Common.CQRS.Events;
using Misio.Common.CQRS.Events.Commands;
using Misio.Common.Logging.CQRS;
using Misio.EntityFrameworkCore;
using Misio.EntityFrameworkCore.CQRS;
using Serilog;
using System.Threading.Tasks;
using iCBM.Application;
using iCBM.WebApi.SchemaFilters;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

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
                        .AddSqlContext<CbmContext>(configuration)
                        .AddScoped<ICbmContext>(provider => provider.GetRequiredService<CbmContext>())
                        .AddScoped<DbContext>(provider => provider.GetRequiredService<CbmContext>())
                        .AddScoped<DbContextBase>(provider => provider.GetRequiredService<CbmContext>())
                        .AddInMemoryCommandDispatcher()
                        .AddInMemoryEventDispatcher()
                        .AddCommandHandlers()
                        .AddEventHandlers()
                        .AddEventDispatcherCommandDecorator()
                        .AddTransactionCommandDecorator()
                        .AddCommandHandlerLoggingDecorator()
                        .AddEFCoreRepository()
                        .AddSwaggerGen(c =>
                        {
                            c.SchemaGeneratorOptions = new SchemaGeneratorOptions()
                            {
                            };
                            c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebApp1", Version = "v1" });
                        });

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
                    app.UseSwagger();
                    app.UseSwaggerUI(c =>
                    {
                        c.RoutePrefix = string.Empty;
                        c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApp1 v1");
                    });
                    
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

