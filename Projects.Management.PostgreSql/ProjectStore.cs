using Projects.Management.Design;
using Projects.Management.Domain;

namespace Projects.Management.PostgreSql;

internal class ProjectStore(ProjectDbContext db) : ICanStoreProject
{
    public async Task AddAsync(Project project, CancellationToken cancellationToken)
    {
        await db.AddAsync(project, cancellationToken).ConfigureAwait(false);
        await db.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(Project project, CancellationToken cancellationToken)
    {
        db.Update(project);
        await db.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(Project project, CancellationToken cancellationToken)
    {
        db.Remove(project);
        await db.SaveChangesAsync(cancellationToken);
    }
}