using Microsoft.EntityFrameworkCore;
using Tasks.Management.Design;
using Task = Tasks.Management.Domain.Task;

namespace Tasks.Management.PostgreSql;

internal class TaskQueries(TaskDbContext db) : ICanFindTask
{
    public Task<Domain.Task?> FindByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return db.Tasks.FindAsync(new object[] { id }, cancellationToken).AsTask();
    }

    public IAsyncEnumerable<Task> FindByProjectIdAsync(Guid projectId, CancellationToken cancellationToken)
    {
        return db.Tasks.Where(x => x.ProjectId.Equals(projectId)).AsAsyncEnumerable();
    }
}