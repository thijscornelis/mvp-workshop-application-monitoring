using System.Diagnostics.Metrics;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjectManagement.Common;
using Projects.Management.Design;
using Projects.Management.PostgreSql.Design;

namespace Projects.Management.PostgreSql;

public static class ProjectManagementExtensions
{
    public const string MeterName = "Projects.Management.PostgreSql";

    public static IProjectManagementRegistration AddPostgreSql(this IProjectManagementRegistration registration, string connectionStringName)
    {
        var connectionString = registration.Configuration.GetConnectionString(connectionStringName);
        connectionString += ";Database=projects-db;";

        registration.Services.AddPostgreSqlDbContext<ProjectDbContext>(builder => builder.UseNpgsql(connectionString));
        registration.Services.AddScoped<ICanStoreProject, ProjectStore>();
        registration.Services.AddScoped<ICanFindProject, ProjectQueries>();

        registration.Services.AddSingleton<ITrackProjects, ProjectMetrics>();
        
        registration.Services.AddOpenTelemetry()
            .WithMetrics(c =>
            {
                c.AddMeter(MeterName);
            });

        return registration;
    }
}