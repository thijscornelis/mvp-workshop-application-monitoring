using System.Diagnostics.Metrics;
using Microsoft.Extensions.DependencyInjection;
using Projects.Management.PostgreSql.Design;

namespace Projects.Management.PostgreSql;

internal class ProjectMetrics : ITrackProjects
{
    private readonly IServiceProvider _serviceProvider;

    public ProjectMetrics(IMeterFactory factory, IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
        var meter = factory.Create(ProjectManagementExtensions.MeterName);
        meter.CreateObservableGauge("projects.count", GetProjectsCount);
    }

    private int GetProjectsCount()
    {
        using var scope = _serviceProvider.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<ProjectDbContext>();
        return db.Projects.Count();
    }
}