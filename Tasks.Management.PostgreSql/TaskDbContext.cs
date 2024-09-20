using Microsoft.EntityFrameworkCore;

namespace Tasks.Management.PostgreSql;

public class TaskDbContext : DbContext
{
    public DbSet<Domain.Task> Tasks { get; set; }

    public TaskDbContext(DbContextOptions<TaskDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(TaskDbContext).Assembly);
    }
}