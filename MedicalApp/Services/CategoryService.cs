using MedicalApp.Models;
using MedicalApp.Utilities;

namespace MedicalApp.Services;

public class CategoryService
{
    public void CreateCategory(Category category)
    {

        Array.Resize(ref DB.categories, DB.categories.Length + 1);
        DB.categories[^1] = category;
        Colored.WriteLine("Category successfully created", ConsoleColor.Green);
    }
}
