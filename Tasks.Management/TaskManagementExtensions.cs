using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tasks.Management.Design;

namespace Tasks.Management;

public static class TaskManagementExtensions
{
    public static IServiceCollection AddTaskManagement(this IServiceCollection serviceCollection, IConfiguration configuration, Action<ITaskManagementRegistration> configure)
    {
        var registration = new TaskManagementRegistration(serviceCollection, configuration);
        configure(registration);
        registration.Services.AddTransient<ITaskManagementFacade, TaskManagementFacade>();
        return serviceCollection;
    }
}