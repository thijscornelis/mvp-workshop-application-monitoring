using ProjectManagement.AppHost;

DistributedApplication.CreateBuilder(args)
    .AddProjectsApi()
    .AddTaskApi()
    .Build()
    .Run();