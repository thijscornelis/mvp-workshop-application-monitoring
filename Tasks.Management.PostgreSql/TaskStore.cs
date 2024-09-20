using Tasks.Management.Design;

namespace Tasks.Management.PostgreSql;

internal class TaskStore(TaskDbContext db) : ICanStoreTask
{
    public async Task<Domain.Task> AddAsync(Domain.Task task, CancellationToken cancellationToken)
    {
        await db.Tasks.AddAsync(task, cancellationToken);
        await db.SaveChangesAsync(cancellationToken);
        return task;
    }

    public async Task<Domain.Task> UpdateAsync(Domain.Task task, CancellationToken cancellationToken)
    {
        db.Update(task);
        await db.SaveChangesAsync(cancellationToken);
        return task;
    }

    public async Task DeleteAsync(Domain.Task task, CancellationToken cancellationToken)
    {
        db.Tasks.Remove(task);
        await db.SaveChangesAsync(cancellationToken);
    }
}