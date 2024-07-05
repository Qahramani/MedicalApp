namespace MedicalApp.Models;

public static class DB
{
    public static User[] users;
    public static Category[] categories;
    public static Medicine[] medicines;
    static DB()
    {
        users = new User[0];
        categories = new Category[0];
        medicines = new Medicine[0];
    }

    public static void PrintUsersInfo(int userId)
    {
        Console.WriteLine("- Users List -");
        foreach (var user in users)
        {
            if(userId == user.Id) 
            Console.WriteLine(user);
        }
    }
    public static void PrintCategoriesInfo(int userId)
    {
        Console.WriteLine("- Categories List -");
        foreach (var category in categories)
        {
            if (userId == category.UserId)

                Console.WriteLine(category);
        }
    }
    public static void PrintMedicinesInfo(int userId)
    {
        Console.WriteLine("- Medicines List -");
        foreach (var medicine in medicines)
        {
            if (userId == medicine.UserId)
                Console.WriteLine(medicine);
        }
    }
}
