using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;
using Serilog.Formatting.Json;
using Serilog.Sinks.SystemConsole.Themes;

namespace ProjectManagement.Common.Logging;

public static class LoggingExtensions
{
    public static void SetupLogging(this IHostApplicationBuilder builder)
    {
        builder.Logging.ClearProviders();

        builder.Services.AddSerilog(c =>
        {
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
            c.WriteTo.File(new JsonFormatter(),
                "logs/log.json", rollingInterval: RollingInterval.Hour, retainedFileTimeLimit: TimeSpan.FromDays(7));
        });
    }

    public static void SetupLogging(this WebApplication app)
    {
        app.UseMiddleware<LogRequestDurationMiddleware>();
    }
}