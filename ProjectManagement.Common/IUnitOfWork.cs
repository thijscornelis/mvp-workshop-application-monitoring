namespace ProjectManagement.Common;

public interface IUnitOfWork : IDisposable
{
    Task StartAsync(CancellationToken cancellationToken);
    Task CommitAsync(CancellationToken cancellationToken);
    Task RollbackAsync(CancellationToken cancellationToken);
}