using System.Collections.Generic;
using Acnys.Core.AspNet;
using Acnys.Core.AspNet.Request;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.SystemConsole.Themes;
using Swanker.Test.Application.QueryHandlers;

namespace Swanker.Test.Web
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateWebHostBuilder(string[] args) =>

            Host.CreateDefaultBuilder(args)

                .AddAutofac()
                .AddSerilog((context, config) => config
                    .WriteTo.Console(
                        outputTemplate:
                        "[{Timestamp:HH:mm:ss+fff}{EventType:x8} {Level:u3}][{App}] {Message:lj} <-- [{SourceContext}]{NewLine}{Exception}",
                        theme: AnsiConsoleTheme.Code)
                    .Enrich.FromLogContext()
                    .Enrich.WithProperty("App", "SMC")
                    .MinimumLevel.Verbose()
                    .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                    .MinimumLevel.Override("System", LogEventLevel.Warning))

                .AddHealthChecks((context, builder) => builder.AddCheck("Self", () => HealthCheckResult.Healthy(), new List<string> { "Liveness", "Readiness" }))
                .AddRequests()
                .RegisterRequestHandlersFromAssemblyOf<MyQueryHandler>()
                .AddRequestValidation()
                .AddHttpRequestHandler()
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}
