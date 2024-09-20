using Projects.Management.Domain;

namespace Projects.Management.Design;

public interface ICanStoreProject
{
    Task AddAsync(Project project, CancellationToken cancellationToken);
    Task UpdateAsync(Project project, CancellationToken cancellationToken);
    Task DeleteAsync(Project project, CancellationToken cancellationToken);
}