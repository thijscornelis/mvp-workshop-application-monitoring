namespace ProjectManagement.Common;

public interface ITrackUnitOfWork
{
    void Started();
    void Completed();
}