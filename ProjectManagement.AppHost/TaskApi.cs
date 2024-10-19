namespace ProjectManagement.AppHost;

internal static class TaskApi
{
    internal static IDistributedApplicationBuilder AddTaskApi(this IDistributedApplicationBuilder builder)
    {
        var tasksDatabase = builder.CreatePostgreSqlDatabase("tasks-db");
        var rabbitMq = builder.CreateRabbitMqServer();
        builder.AddProject<Projects.Tasks_Api>("tasks-api")
            .WithReference(tasksDatabase)
            .WithReference(rabbitMq)
            .WaitFor(tasksDatabase)
            .WaitFor(rabbitMq);
        return builder;
    }
}