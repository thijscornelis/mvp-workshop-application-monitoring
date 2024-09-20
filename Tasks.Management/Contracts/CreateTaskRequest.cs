namespace Tasks.Management.Contracts
{
    public record CreateTaskRequest(Guid ProjectId, string Name);
}
