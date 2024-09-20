using Microsoft.EntityFrameworkCore;
using Projects.Management.Design;
using Projects.Management.Domain;

namespace Projects.Management.PostgreSql;

internal class ProjectQueries(ProjectDbContext db) : ICanFindProject
{
    public Task<Project?> FindByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return db.Projects.FindAsync([id], cancellationToken).AsTask();
    }
    public Task<Project?> FindByNameAsync(string name, CancellationToken cancellationToken)
    {
        return db.Projects.FirstOrDefaultAsync(p => p.Name == name, cancellationToken);
    }
}