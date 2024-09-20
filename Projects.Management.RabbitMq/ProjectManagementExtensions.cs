using Microsoft.Extensions.DependencyInjection;
using Projects.Management.Design;

namespace Projects.Management.RabbitMq;

public static class ProjectManagementExtensions
{
    public static IProjectManagementRegistration AddRabbitMq(this IProjectManagementRegistration registration)
    {
        registration.Services.AddTransient<ICanPublishProjectDeleted, ProjectDeletedPublisher>();
        return registration;
    }
}