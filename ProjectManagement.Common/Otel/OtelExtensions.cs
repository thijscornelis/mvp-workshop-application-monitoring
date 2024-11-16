using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Npgsql;
using OpenTelemetry;
using OpenTelemetry.Metrics;
using OpenTelemetry.Trace;

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
                c.AddMeter(UnitOfWorkMetrics.MeterName);
            });

        builder.Services.AddSingleton<ITrackUnitOfWork, UnitOfWorkMetrics>();
    }

    public static void AddTracing(this IHostApplicationBuilder builder, params string[] customSources)
    {
        builder.Services.AddOpenTelemetry()
            .WithTracing(c =>
            {
                if (builder.Environment.IsDevelopment())
                {
                    c.SetSampler(new AlwaysOnSampler());
                }

                c.AddAspNetCoreInstrumentation();
                c.AddHttpClientInstrumentation();
                c.AddNpgsql();
                c.AddSource(customSources);
                c.AddOtlpExporter();
            });
    }
}