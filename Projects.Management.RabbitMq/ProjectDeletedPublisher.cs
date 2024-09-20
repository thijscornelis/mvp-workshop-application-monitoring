using Projects.Management.Design;
using Projects.Management.Events;

namespace Projects.Management.RabbitMq;

internal class ProjectDeletedPublisher : ICanPublishProjectDeleted
{
    public Task PublishAsync(Guid projectId, CancellationToken cancellationToken)
    {
        var @event = new ProjectDeleted(projectId);
        return Task.CompletedTask;
    }
}