using System.Diagnostics.Metrics;

namespace ProjectManagement.Common;

public class UnitOfWorkMetrics : ITrackUnitOfWork
{
    public const string MeterName = "ProjectManagement.Common";

    private readonly Counter<int> _numberOfCompletedUnitsOfWork;
    private readonly UpDownCounter<int> _numberOfActiveUnitsOfWork;
    
    public UnitOfWorkMetrics(IMeterFactory factory)
    {
        var meter = factory.Create(MeterName);
        _numberOfCompletedUnitsOfWork = meter.CreateCounter<int>("units_of_work.completed");
        _numberOfActiveUnitsOfWork = meter.CreateUpDownCounter<int>("units_of_work.active");
    }

    public void Started()
    {
        _numberOfActiveUnitsOfWork.Add(1);
    }

    public void Completed()
    {
        _numberOfActiveUnitsOfWork.Add(-1);
        _numberOfCompletedUnitsOfWork.Add(1);
    }
}