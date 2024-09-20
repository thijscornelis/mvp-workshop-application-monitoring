using Microsoft.Extensions.DependencyInjection;
using Tasks.Management.Design;

namespace Tasks.Management.RestApi;

public static class TaskManagementExtensions
{
    public static ITaskManagementRegistration AddRestApi(this ITaskManagementRegistration registration)
    {
        registration.Services.AddControllers().AddApplicationPart(typeof(TaskManagementExtensions).Assembly);
        return registration;
    }
}