namespace HA.Domain.Entities;

public class Category
{
    protected Category() { }
    public Category(string name)
    {
        Name = name;
    }

    public Guid Id { get; set; }
    public string Name { get; protected set; }
}
