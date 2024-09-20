namespace ProjectManagement.AppHost;

internal static class ProjectsApi
{
    internal static IDistributedApplicationBuilder AddProjectsApi(this IDistributedApplicationBuilder builder)
    {
        var projectsDatabase = builder.CreatePostgreSqlDatabase("projects-db");

        builder.AddProject<Projects.Projects_Api>("projects-api")
            .WithReference(projectsDatabase)
            .WaitFor(projectsDatabase);

        return builder;
    }

    
}