using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace ProjectManagement.Common;

public class UnitOfWork<TDbContext>(ITrackUnitOfWork unitOfWorkMetrics, TDbContext dbContext) : IUnitOfWork where TDbContext : DbContext
{
    private IDbContextTransaction? _transaction;

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        
        _transaction = await dbContext.Database.BeginTransactionAsync(cancellationToken);
        unitOfWorkMetrics.Started();
    }

    public async Task CommitAsync(CancellationToken cancellationToken)
    {
        if (_transaction == null)
        {
            return;
        }
        await _transaction.CommitAsync(cancellationToken);
        unitOfWorkMetrics.Completed();
    }

    public async Task RollbackAsync(CancellationToken cancellationToken)
    {
        if (_transaction == null)
        {
            return;
        }
        await _transaction.RollbackAsync(cancellationToken);
    }

    public void Dispose()
    {
        _transaction?.Dispose();
    }
}