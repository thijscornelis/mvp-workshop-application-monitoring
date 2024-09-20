namespace Tasks.Management.Domain;

public class Task
{
    public Task(Guid projectId, string name)
    {
        ProjectId = projectId;
        Name = name;
    }

    public Guid Id { get; set; }
    public Guid ProjectId { get; set; }
    public string Name { get; set; }
}