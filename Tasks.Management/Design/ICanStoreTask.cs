

namespace Tasks.Management.Design;

public interface ICanStoreTask
{
    Task<Domain.Task> AddAsync(Domain.Task task, CancellationToken cancellationToken);
    Task<Domain.Task> UpdateAsync(Domain.Task task, CancellationToken cancellationToken);
    Task DeleteAsync(Domain.Task task, CancellationToken cancellationToken);
}