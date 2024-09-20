using Tasks.Management.Contracts;
using Task = Tasks.Management.Domain.Task;

namespace Tasks.Management.Design;

public interface ITaskManagementFacade
{
    Task<Task> CreateTaskAsync(CreateTaskRequest request, CancellationToken cancellationToken);
    Task<Task?> FindTaskByIdAsync(Guid id, CancellationToken cancellationToken);
    System.Threading.Tasks.Task DeleteTaskAsync(Guid id, CancellationToken cancellationToken);
}