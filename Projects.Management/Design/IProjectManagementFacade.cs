using Projects.Management.Contracts;
using Projects.Management.Domain;

namespace Projects.Management.Design;

public interface IProjectManagementFacade
{
    Task<Project> CreateProjectAsync(CreateProjectRequest request, CancellationToken cancellationToken);
    Task<Project?> FindProjectByIdAsync(Guid id, CancellationToken cancellationToken);
    Task DeleteProjectAsync(Guid id, CancellationToken cancellationToken);
}