using Destructurama;
using Microsoft.Extensions.Logging;
using ProjectManagement.Common.Logging;
using ProjectManagement.Common.Otel;
using Projects.Management;
using Projects.Management.PostgreSql;
using Projects.Management.RabbitMq;
using Projects.Management.RestApi;
using Projects.Management.RestApi.Contracts;

namespace Projects.Api;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.SetupLogging(c =>
        {
            c.ByIgnoringProperties<CreateProjectRequestDto>(x => x.Owner);
        });
        builder.AddMetrics();

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddHealthChecks();
        builder.Services.AddProjectManagement(builder.Configuration, c => c
            .AddPostgreSql("projects-db-server")
            .AddRestApi()
            .AddRabbitMq()
        );

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();
        app.UseHealthChecks("/api/health");
        app.SetupLogging();

        if (app.Environment.IsDevelopment())
        {
            await using var scope = app.Services.CreateAsyncScope();
            var db = scope.ServiceProvider.GetRequiredService<ProjectDbContext>();
            await db.Database.EnsureDeletedAsync(CancellationToken.None);
            await db.Database.EnsureCreatedAsync(CancellationToken.None);
        }

        await app.RunAsync();
    }
}
