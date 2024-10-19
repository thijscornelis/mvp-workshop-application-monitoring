using System.Reflection;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Tasks.Management.Design;

namespace Tasks.Management.RabbitMq;
public static class TaskManagementExtensions
{
    public static ITaskManagementRegistration AddRabbitMq(this ITaskManagementRegistration registration, string rabbitMqConnectionStringName)
    {
        registration.Services.AddMassTransit(c =>
        {
            c.AddConsumer<DeleteTasksRelatedToProjectOnProjectDeleted>();
            c.UsingRabbitMq((context, config) =>
            {
                config.ConfigureEndpoints(context);
                var connectionString = registration.Configuration.GetConnectionString(rabbitMqConnectionStringName) ?? throw new ArgumentNullException();
                config.Host(new Uri(connectionString));
            });
        });
        return registration;
    }
}