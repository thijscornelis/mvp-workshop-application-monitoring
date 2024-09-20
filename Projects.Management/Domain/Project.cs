namespace Projects.Management.Domain;

public class Project
{
    public Project(string name)
    {
        Name = name;
    }

    public Guid Id { get; set; }
    public string Name { get; set; }
}