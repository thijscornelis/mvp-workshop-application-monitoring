using Projects.Management.Domain;

namespace Projects.Management.Design;

public interface ICanFindProject
{
    Task<Project?> FindByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<Project?> FindByNameAsync(string name, CancellationToken cancellationToken);
}