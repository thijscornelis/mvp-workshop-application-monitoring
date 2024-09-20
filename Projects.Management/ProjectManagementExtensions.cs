using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Projects.Management.Contracts;
using Projects.Management.Design;
using Projects.Management.Domain;

namespace Projects.Management;

public static class ProjectManagementExtensions
{
    public static IServiceCollection AddProjectManagement(this IServiceCollection serviceCollection,
        IConfiguration configuration, Action<IProjectManagementRegistration> configure)
    {
        var registration = new ProjectManagementRegistration(serviceCollection, configuration);
        registration.Services.AddTransient<ProjectManagementFacade>();
        registration.Services.AddTransient<IProjectManagementFacade>(sp =>
            new RandomFacadeRequestDelay(sp.GetRequiredService<ProjectManagementFacade>()));
        configure?.Invoke(registration);
        return registration.Services;
    }
}

internal class RandomFacadeRequestDelay(ProjectManagementFacade facade) : IProjectManagementFacade
{
    public async Task<Project> CreateProjectAsync(CreateProjectRequest request, CancellationToken cancellationToken)
    {
        await DelayAsync(cancellationToken);
        return await facade.CreateProjectAsync(request, cancellationToken);
    }

    public async Task<Project?> FindProjectByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        await DelayAsync(cancellationToken);
        return await facade.FindProjectByIdAsync(id, cancellationToken);
    }

    public async Task DeleteProjectAsync(Guid id, CancellationToken cancellationToken)
    {
        await DelayAsync(cancellationToken);
        await facade.DeleteProjectAsync(id, cancellationToken);
    }

    private Task DelayAsync(CancellationToken cancellationToken)
    {
        var random = new Random();
        var delay = random.Next(10, 700);
        return Task.Delay(delay, cancellationToken);
    }
}