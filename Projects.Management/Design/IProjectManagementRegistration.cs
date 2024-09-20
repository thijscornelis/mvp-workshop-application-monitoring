using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Projects.Management.Design;

public interface IProjectManagementRegistration
{
    public IServiceCollection Services { get; set; }
    public IConfiguration Configuration { get; set; }
}