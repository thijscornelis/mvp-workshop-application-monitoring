using MassTransit;
using Projects.Management.Design;
using Projects.Management.Events;

namespace Projects.Management.RabbitMq;

internal class ProjectDeletedPublisher(IPublishEndpoint publisher) : ICanPublishProjectDeleted
{
    public Task PublishAsync(Guid projectId, CancellationToken cancellationToken)
    {
        var @event = new ProjectDeleted(projectId);
        return publisher.Publish(@event, cancellationToken);
    }
}