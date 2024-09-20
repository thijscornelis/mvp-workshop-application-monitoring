using Tasks.Management.Contracts;
using Tasks.Management.Design;
using Task = Tasks.Management.Domain.Task;

namespace Tasks.Management;

internal class TaskManagementFacade(ICanStoreTask store, ICanFindTask finder) : ITaskManagementFacade
{
    public async Task<Task> CreateTaskAsync(CreateTaskRequest request, CancellationToken cancellationToken)
    {
        var task = new Task(request.ProjectId, request.Name);
        await store.AddAsync(task, cancellationToken);
        return task;
    }

    public Task<Task?> FindTaskByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return finder.FindByIdAsync(id, cancellationToken);
    }

    public async System.Threading.Tasks.Task DeleteTaskAsync(Guid id, CancellationToken cancellationToken)
    {
        var task = await finder.FindByIdAsync(id, cancellationToken);
        if (task is null)
        {
            return;
        }
        await store.DeleteAsync(task, cancellationToken);
    }
}