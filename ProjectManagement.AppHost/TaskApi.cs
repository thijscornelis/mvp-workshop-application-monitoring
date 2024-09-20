namespace ProjectManagement.AppHost;

internal static class TaskApi
{
    internal static IDistributedApplicationBuilder AddTaskApi(this IDistributedApplicationBuilder builder)
    {
        var tasksDatabase = builder.CreatePostgreSqlDatabase("tasks-db");
        builder.AddProject<Projects.Tasks_Api>("tasks-api")
            .WithReference(tasksDatabase)
            .WaitFor(tasksDatabase);
        return builder;
    }
}