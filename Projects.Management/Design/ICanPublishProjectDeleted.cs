namespace Projects.Management.Design;

public interface ICanPublishProjectDeleted
{
    Task PublishAsync(Guid projectId, CancellationToken cancellationToken);
}