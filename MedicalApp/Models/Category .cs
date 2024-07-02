namespace MedicalApp.Models;

public class Category : BaseEntity
{
    private static int _id;
    public string Name { get; set; }
    public Category(string name)
    {
        Name = name;
        Id = ++_id;
    }
    public override string ToString()
    {
        return $"Name: {Name}, Id: {Id}";
    }

}
