using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OpenTelemetry.Metrics;

namespace ProjectManagement.Common.Otel;

public static class OtelExtensions
{
    public static void AddMetrics(this IHostApplicationBuilder builder)
    {
        builder.Services.AddOpenTelemetry()
            .WithMetrics(c =>
            {
                c.AddAspNetCoreInstrumentation();
                c.AddHttpClientInstrumentation();
                c.AddOtlpExporter();
            });
    }
}