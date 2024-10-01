namespace Projects.Management.Domain;

public class Project
{
    public Project(string name, string owner)
    {
        Name = name;
        Owner = owner;
    }

    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Owner { get; set; }
}