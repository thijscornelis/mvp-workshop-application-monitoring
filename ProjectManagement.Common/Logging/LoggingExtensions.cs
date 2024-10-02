using Destructurama;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Configuration;
using Serilog.Events;
using Serilog.Formatting.Json;
using Serilog.Sinks.SystemConsole.Themes;

namespace ProjectManagement.Common.Logging;

public static class LoggingExtensions
{
    public static void SetupLogging(this IHostApplicationBuilder builder, Action<LoggerDestructuringConfiguration>? destructuringConfiguration = null)
    {
        builder.Logging.ClearProviders();

        builder.Services.AddHttpContextAccessor();
        builder.Services.AddSerilog(c =>
        {
            c.Enrich.FromLogContext().Enrich.WithCorrelationId(addValueIfHeaderAbsence: true);

            if (destructuringConfiguration != null)
            {
                destructuringConfiguration.Invoke(c.Destructure);
            }

            if (builder.Environment.IsDevelopment())
            {
                c.MinimumLevel.Verbose();
            }
            else
            {
                c.MinimumLevel.Information();
            }

            c.MinimumLevel.Override("Microsoft.EntityFrameworkCore", LogEventLevel.Warning);
            c.MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning);
            c.WriteTo.Console(theme: AnsiConsoleTheme.Code, applyThemeToRedirectedOutput: true);
            c.WriteTo.OpenTelemetry();
        });
    }

    public static void SetupLogging(this WebApplication app)
    {
        app.UseMiddleware<LogRequestDurationMiddleware>();
    }
}