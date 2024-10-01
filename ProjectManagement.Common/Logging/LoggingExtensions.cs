using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ProjectManagement.Common.Logging;

public static class LoggingExtensions
{
    public static void SetupLogging(this IHostApplicationBuilder builder)
    {
        builder.Logging
            .ClearProviders()
            .AddConsole()
            .SetMinimumLevel(builder.Environment.IsDevelopment() ? LogLevel.Trace : LogLevel.Information)
            .AddFilter("Microsoft.AspNetCore", LogLevel.Warning)
            .AddFilter("Microsoft.EntityFrameworkCore", LogLevel.Warning);
    }

    public static void SetupLogging(this WebApplication app )
    {
        app.UseMiddleware<LogRequestDurationMiddleware>();
    }
}