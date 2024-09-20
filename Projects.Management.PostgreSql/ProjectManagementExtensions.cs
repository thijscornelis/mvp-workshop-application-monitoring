using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjectManagement.Common;
using Projects.Management.Design;

namespace Projects.Management.PostgreSql;

public static class ProjectManagementExtensions
{
    public static IProjectManagementRegistration AddPostgreSql(this IProjectManagementRegistration registration, string connectionStringName)
    {
        var connectionString = registration.Configuration.GetConnectionString(connectionStringName);
        connectionString += ";Database=projects-db;";

        registration.Services.AddPostgreSqlDbContext<ProjectDbContext>(builder => builder.UseNpgsql(connectionString));
        registration.Services.AddScoped<ICanStoreProject, ProjectStore>();
        registration.Services.AddScoped<ICanFindProject, ProjectQueries>();
        return registration;
    }
}