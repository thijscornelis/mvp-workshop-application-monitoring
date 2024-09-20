using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tasks.Management.Design;

namespace Tasks.Management;

internal class TaskManagementRegistration : ITaskManagementRegistration
{
    public TaskManagementRegistration(IServiceCollection serviceCollection, IConfiguration configuration)
    {
        Services = serviceCollection;
        Configuration = configuration;
    }

    public IServiceCollection Services { get; set; }
    public IConfiguration Configuration { get; set; }
}