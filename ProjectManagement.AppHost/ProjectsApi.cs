namespace ProjectManagement.AppHost;

internal static class ProjectsApi
{
    internal static IDistributedApplicationBuilder AddProjectsApi(this IDistributedApplicationBuilder builder)
    {
        var projectsDatabase = builder.CreatePostgreSqlDatabase("projects-db");
        var rabbitMq = builder.CreateRabbitMqServer();
        builder.AddProject<Projects.Projects_Api>("projects-api")
            .WithReference(projectsDatabase)
            .WithReference(rabbitMq)
            .WaitFor(projectsDatabase)
            .WaitFor(rabbitMq);

        return builder;
    }

    
}