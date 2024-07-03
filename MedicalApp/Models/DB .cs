﻿namespace MedicalApp.Models;

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

    public static void PrintUsersInfo()
    {
        Console.WriteLine("- Users List -");
        foreach (var user in users)
        {
            Console.WriteLine(user);
        }
    }
    public static void PrintCategoriesInfo()
    {
        Console.WriteLine("- Categories List -");
        foreach (var category in categories)
        {
            Console.WriteLine(category);
        }
    }
    public static void PrintMedicinesInfo()
    {
        Console.WriteLine("- Medicines List -");
        foreach (var medicine in medicines)
        {
            Console.WriteLine(medicine);
        }
    }
}
