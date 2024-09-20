using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjectManagement.Common;
using Tasks.Management.Design;

namespace Tasks.Management.PostgreSql;

public static class TaskManagementExtensions
{
    public static ITaskManagementRegistration AddPostgreSql(this ITaskManagementRegistration registration, string connectionStringName)
    {

        var connectionString = registration.Configuration.GetConnectionString(connectionStringName);
        connectionString += ";Database=tasks-db;";
        
        registration.Services.AddPostgreSqlDbContext<TaskDbContext>(builder => builder.UseNpgsql(connectionString));
        registration.Services.AddScoped<ICanStoreTask, TaskStore>();
        registration.Services.AddScoped<ICanFindTask, TaskQueries>();
        return registration;
    }
}