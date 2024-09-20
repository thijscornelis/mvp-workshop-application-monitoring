using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Tasks.Management.PostgreSql.EntityTypeConfigurations;

internal class TaskEntityTypeConfiguration : IEntityTypeConfiguration<Domain.Task>
{
    public void Configure(EntityTypeBuilder<Domain.Task> builder)
    {
        builder.ToTable("tasks");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd();
        builder.Property(x => x.ProjectId).HasColumnName("project_id").IsRequired();
        builder.Property(x => x.Name).HasColumnName("name").IsRequired();
    }
}