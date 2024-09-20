using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Projects.Management.Design;

namespace Projects.Management;

public class ProjectManagementRegistration : IProjectManagementRegistration
{
    public IServiceCollection Services { get; set; }
    public IConfiguration Configuration { get; set; }

    internal ProjectManagementRegistration(IServiceCollection serviceCollection, IConfiguration configuration)
    {
        Services = serviceCollection;
        Configuration = configuration;
    }
}