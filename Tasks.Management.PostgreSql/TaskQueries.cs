using Tasks.Management.Design;

namespace Tasks.Management.PostgreSql;

internal class TaskQueries(TaskDbContext db) : ICanFindTask
{
    public Task<Domain.Task?> FindByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return db.Tasks.FindAsync(new object[] { id }, cancellationToken).AsTask();
    }
}