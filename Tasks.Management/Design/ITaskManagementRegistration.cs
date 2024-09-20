using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Tasks.Management.Design;

public interface ITaskManagementRegistration
{
    public IServiceCollection Services { get; set; }
    public IConfiguration Configuration { get; set; }
}