namespace MedicalApp.Models;

public class Category : BaseEntity
{
    private static int _id;
    public int UserId { get; set; }

    public string Name { get; set; }
    public Category(string name, int userId)
    {
        Name = name;
        Id = ++_id;
        UserId = userId;
    }
    public override string ToString()
    {
        return $"Category Name: {Name}, Id: {Id}";
    }

}
