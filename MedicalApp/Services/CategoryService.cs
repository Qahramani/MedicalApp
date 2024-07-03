using MedicalApp.Models;

namespace MedicalApp.Services;

public class CategoryService
{
    public void CreateCategory(Category category)
    {
        Array.Resize(ref DB.categories, DB.categories.Length + 1);
        DB.categories[^1] = category;
        Console.WriteLine("Category successfully created");
    }
}
