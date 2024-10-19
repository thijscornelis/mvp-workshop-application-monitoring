namespace ProjectManagement.AppHost;

internal static class RabbitMq
{
    private static IResourceBuilder<ParameterResource>? _user;
    private static IResourceBuilder<ParameterResource>? _password;
    private static IResourceBuilder<RabbitMQServerResource>? _rabbitMq;
    internal static IResourceBuilder<RabbitMQServerResource> CreateRabbitMqServer(this IDistributedApplicationBuilder builder)
    {
        _user ??= builder.AddParameter("User");
        _password ??= builder.AddParameter("Password");

        return _rabbitMq ??= builder.AddRabbitMQ("rabbitmq", _user, _password, port: 5672)
            .WithManagementPlugin(15672)
            .WithHealthCheck();
    }
}