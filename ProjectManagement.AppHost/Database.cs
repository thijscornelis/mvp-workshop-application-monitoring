namespace ProjectManagement.AppHost;

internal static class Database
{
    internal static IResourceBuilder<PostgresServerResource> CreatePostgreSqlDatabase(this IDistributedApplicationBuilder builder, string databaseName)
    {
        var databaseServer = builder
            .AddPostgres($"{databaseName}-server")
            .WithEnvironment("POSTGRES_DB", databaseName)
            .WithHealthCheck()
            .WithDataVolume()
            .WithPgWeb();

        databaseServer.AddDatabase(databaseName);

        return databaseServer;

    }
}