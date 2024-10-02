using ProjectManagement.Common.Logging;
using ProjectManagement.Common.Otel;
using Tasks.Management;
using Tasks.Management.PostgreSql;
using Tasks.Management.RestApi;

namespace Tasks.Api;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.SetupLogging();
        builder.AddMetrics();

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddHealthChecks();
        builder.Services.AddTaskManagement(builder.Configuration, c =>
        {
            c.AddPostgreSql("tasks-db-server");
            c.AddRestApi();
        });
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
            var db = scope.ServiceProvider.GetRequiredService<TaskDbContext>();
            await db.Database.EnsureDeletedAsync(CancellationToken.None);
            await db.Database.EnsureCreatedAsync(CancellationToken.None);
        }

        await app.RunAsync();
    }
}
