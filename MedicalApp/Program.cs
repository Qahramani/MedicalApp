using MedicalApp.Exceptions;
using MedicalApp.Models;
using MedicalApp.Services;
using MedicalApp.Utilities;

namespace MedicalApp;

public class Program
{
    static void Main(string[] args)
    {
        UserService userService = new UserService();
        MedicineService medicineService = new MedicineService();
        CategoryService categoryService = new CategoryService();
        User myUser = new("", "", "");
    restartUserMenu:
        Console.Clear();
        Console.WriteLine("----- User Menu -----");
        Console.Write("[1] Create user\n" +
            "[2] User Login\n" +
            "[0] Exit\n" +
            ">>> ");
        string option = Console.ReadLine();

        switch (option)
        {
            case "1":
                CreateUser(userService);
                Console.ReadLine();
                goto restartUserMenu;

            case "2":
                #region Login Process

                Console.WriteLine("----- Login Process -----");
                Console.Write("Email: ");
                string email = Console.ReadLine();
                Console.Write("Password: ");
                string password = Console.ReadLine();

                try
                {
                    myUser = userService.Login(email, password);
                    Console.Clear();
                }
                catch (UserNotFoundException ex)
                {
                    Colored.WriteLine($"Error: {ex.Message}", ConsoleColor.Red);
                    Console.ReadLine();
                    goto restartUserMenu;
                }
                catch (Exception ex)
                {
                    Colored.WriteLine($"Error: {ex.Message}", ConsoleColor.Red);
                    Console.ReadLine();
                    goto restartUserMenu;
                }
                break;
            #endregion
            case "0":
                Colored.WriteLine("Goodbye!", ConsoleColor.DarkYellow);
                return;
            default:
                Console.WriteLine("Please enter valid option");
                Console.ReadLine();
                goto restartUserMenu;
        }

    restartMedicineMenu:
        Console.Clear();
        Console.WriteLine($"Welcome, {myUser.Fullname}!");
        
        Console.WriteLine("----- Medicine service Menu -----");
        Console.Write("[1] Create Medicine\n" +
            "[2] Remove Medicine\n" +
            "[3] Update Medicine\n" +
            "[4] Get Medicine\n" +
            "[5] Create Category\n" +
            "[6] Print all categories\n" +
            "[0] Exit\n" +
            ">>> ");
        option = Console.ReadLine();
        switch (option)
        {
            case "1":
                var tempMedForCreate = CreateMedicine(myUser.Id);
                if (!(tempMedForCreate == null))
                {
                    medicineService.CreateMedicine(tempMedForCreate);
                }
                else
                {
                    Colored.WriteLine("Category is not found", ConsoleColor.Red);
                }
                Console.ReadLine();
                goto restartMedicineMenu;
            case "2":
                try
                {
                    Console.WriteLine("----- Remove Process -----");
                    DB.PrintMedicinesInfo(myUser.Id);
                    Console.Write("Id: ");
                    int medicineId = int.Parse(Console.ReadLine());
                    medicineService.RemoveMedicine(medicineId, myUser.Id);
                }
                catch (NotFoundException ex)
                {
                    Colored.WriteLine($"Error: {ex.Message}", ConsoleColor.Red);
                }
                catch (Exception ex)
                {
                    Colored.WriteLine($"Error: {ex.Message}", ConsoleColor.Red);
                }
                Console.ReadLine();
                goto restartMedicineMenu;
            case "3":
                try
                {

                    Console.WriteLine("----- Update Process -----");
                    DB.PrintMedicinesInfo(myUser.Id);
                    Console.Write("Id of medicine that you want update: ");
                    int Id = int.Parse(Console.ReadLine());
                    var tempMedForUpdate = CreateMedicine(myUser.Id);
                    if (!(tempMedForUpdate == null))
                        medicineService.UpdateMedicine(Id, tempMedForUpdate, myUser.Id);
                    else
                        Colored.WriteLine("Category is not found", ConsoleColor.Red);

                }
                catch (NotFoundException ex)
                {
                    Colored.WriteLine($"Error: {ex.Message}", ConsoleColor.Red);
                }
                catch (Exception ex)
                {
                    Colored.WriteLine($"Error: {ex.Message}", ConsoleColor.Red);
                }
                Console.ReadLine();
                goto restartMedicineMenu;
            case "4":
                Console.Clear();
                GetMedicineBY(medicineService, myUser.Id);
                goto restartMedicineMenu;
            case "5":
                try
                {
                    Console.WriteLine("----- Category creation process -----");
                    Console.Write("Category Name: ");
                    string categoryName = Console.ReadLine();

                    if (categoryName == "")
                        throw new NullReferenceException("Name cannot be empty");

                    foreach (var c in DB.categories)
                    {
                        if (categoryName == c.Name && myUser.Id == c.UserId)
                            throw new Exception("Category with given name already exist");
                    }

                    categoryService.CreateCategory(new Category(categoryName, myUser.Id));
                }
                catch (Exception ex)
                {
                    Colored.WriteLine($"Error: {ex.Message}", ConsoleColor.Red);
                }
                Console.ReadLine();
                goto restartMedicineMenu;
            case "6":
                DB.PrintCategoriesInfo(myUser.Id);
                Console.ReadLine();
                goto restartMedicineMenu;
            case "0":
                Console.Clear();
                break;
            default:
                Colored.WriteLine("Please enter valid input", ConsoleColor.Red);
                Console.ReadLine();
                goto restartMedicineMenu;
        }
        goto restartUserMenu;
    }

    private static void GetMedicineBY(MedicineService medicineService, int userId)
    {
        string option;
    restartGetMedicineMenu:
        Console.Write("----- Get Medicine By -----\n" +
            "[1] Id\n" +
            "[2] Name\n" +
            "[3] Category\n" +
            "[4] All Medicines\n" +
            "[0] Exit\n" +
            ">>> ");
        option = Console.ReadLine();
        try
        {

            switch (option)
            {
                case "1":
                    Console.Write("Medicine id: ");
                    int medicineId = int.Parse(Console.ReadLine());
                    medicineService.GetMedicineById(medicineId, userId);
                    break;
                case "2":
                    Console.Write("Medicine Name: ");
                    string medicineName = Console.ReadLine();
                    medicineService.GetMedicineByName(medicineName, userId);
                    break;
                case "3":
                    Console.Write("Medicine Category Id: ");
                    int CategoryId = int.Parse(Console.ReadLine());
                    Medicine[] medicines = medicineService.GetMedicineByCategory(CategoryId, userId);
                    foreach (var med in medicines)
                    {
                        Console.WriteLine(med);
                    }
                    break;
                case "4":
                    DB.PrintMedicinesInfo(userId);
                    break;
                case "0":
                    Console.Clear();
                    return;
                default:
                    Console.WriteLine("Please enter valid input");
                    break;
            }
        }
        catch (NotFoundException ex)
        {
            Colored.WriteLine($"Error: {ex.Message}", ConsoleColor.Red);
        }
        catch (Exception ex)
        {
            Colored.WriteLine($"Error: {ex.Message}", ConsoleColor.Red);
        }
        goto restartGetMedicineMenu;
    }

    private static Medicine CreateMedicine(int userId)
    {
    restartCreation:
        Console.WriteLine("----- Creation Process -----");
        Console.Write("Medicine name: ");
        string medicineName = Console.ReadLine();

        if(medicineName == "")
        {
            Colored.WriteLine("Name cannot be empty", ConsoleColor.Red);
            goto restartCreation;
        }

        Console.Write("Price: ");
        double medicinePrice;
        bool isPriceCorrect = double.TryParse(Console.ReadLine(), out medicinePrice);
        if (!isPriceCorrect || medicinePrice < 0)
        {
            Colored.WriteLine("Invalid input for price", ConsoleColor.Red);
            goto restartCreation;
        }

        Console.WriteLine("Choose category: ");
        DB.PrintCategoriesInfo(userId);
        Console.Write("Category Id: ");
        int categoryId;

        bool isIdCorrect = int.TryParse(Console.ReadLine(), out categoryId);
        if (!isIdCorrect)
        {
            Colored.WriteLine("Error: Input string was not in a correct format.", ConsoleColor.Red);
            goto restartCreation;
        }

        foreach (var category in DB.categories)
        {
            if (category.Id == categoryId && category.UserId == userId)
                return new Medicine(medicineName, medicinePrice, categoryId, userId);
        }
        return null;
    }

    private static void CreateUser(UserService userService)
    {
    restartUserCreation:
        Console.WriteLine("----- User creation -----");
        try
        {
            Console.Write("Fullname: ");
            string userName = Console.ReadLine();
            Console.Write("Email: ");
            string userEmail = Console.ReadLine();

            Validations.IsEmailCorrect(userEmail);

            Console.Write("Password: ");
            string userPassword = Console.ReadLine();

            Validations.IsPasswordCorrect(userPassword);

            User user = new User(userName, userEmail, userPassword);
            userService.AddUser(user);

        }
        catch (WrongPasswordException ex)
        {
            Colored.WriteLine($"Error: {ex.Message}", ConsoleColor.Red);
            goto restartUserCreation;
        }
        catch (WrongEmailException ex)
        {
            Colored.WriteLine($"Error: {ex.Message}", ConsoleColor.Red);
            goto restartUserCreation;
        }
        catch (UserAlreadyExistException ex)
        {
            Colored.WriteLine($"Error: {ex.Message}", ConsoleColor.Red);
            goto restartUserCreation;
        }
    }
}
