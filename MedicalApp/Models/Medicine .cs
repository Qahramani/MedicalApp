namespace MedicalApp.Models;

public class Medicine : BaseEntity
{
    private static int _id;
    public string Name { get; set; }
    public double Price { get; set; }

    public int CategoryId { get; set; }
    public int UserId { get; set; }
    public  DateTime CreatedDate { get; set; }
    public Medicine(string name, double price, int categoryId, int userId )
    {
        Name = name;
        Price = price;
        CategoryId = categoryId;
        UserId = userId;
        CreatedDate = DateTime.Now;
        Id = ++_id;
    }
    public override string ToString()
    {
        return $"Medicine Name: {Name}, Price: {Price}, CategoryId: {CategoryId}, UserId: {UserId}, " +
            $"Creatinon Date: {CreatedDate}, Id: {Id}";
    }
}
