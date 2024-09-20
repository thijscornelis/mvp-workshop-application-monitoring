namespace Tasks.Management.Design;

public interface ICanFindTask
{
    Task<Domain.Task?> FindByIdAsync(Guid id, CancellationToken cancellationToken);
}