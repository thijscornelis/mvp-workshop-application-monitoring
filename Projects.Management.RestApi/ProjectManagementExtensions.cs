using Microsoft.Extensions.DependencyInjection;
using Projects.Management.Design;

namespace Projects.Management.RestApi;

public static class ProjectManagementExtensions
{
    public static IProjectManagementRegistration AddRestApi(this IProjectManagementRegistration registration)
    {
        registration.Services
            .AddControllers()
            .AddApplicationPart(typeof(ProjectManagementExtensions).Assembly);
        return registration;
    }
}