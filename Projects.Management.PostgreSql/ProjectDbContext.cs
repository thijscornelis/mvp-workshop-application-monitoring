using Microsoft.EntityFrameworkCore;
using Projects.Management.Domain;

namespace Projects.Management.PostgreSql;

public class ProjectDbContext : DbContext
{
    public DbSet<Project> Projects { get; set; }

    public ProjectDbContext(DbContextOptions<ProjectDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProjectDbContext).Assembly);
    }
}