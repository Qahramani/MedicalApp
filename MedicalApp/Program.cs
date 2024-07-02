using MedicalApp.Exceptions;
using MedicalApp.Models;
using MedicalApp.Services;

namespace MedicalApp;

public class Program
{
    static void Main(string[] args)
    {
        //UserService userService = new UserService();
        //User user1 = new User("Admin", "admin@gmail.com", "admin123");
        //User user2 = new User("Admin", "admin@gmail.com", "admin123");
        //User user3 = new User("Gunel", "gunel@gmail.com", "gunel123");
        //try
        //{
        //    userService.AddUser(user1);
        //    userService.AddUser(user2);

        //}
        //catch (NotFoundException ex)
        //{
        //    Console.WriteLine(ex.Message);
        //}


        //foreach (var user in DB.users)
        //{
        //    Console.WriteLine(user.ToString());
        //}

        //var myUser = userService.Login("admn@gmail.com", "admin123");
        //Console.WriteLine(myUser.ToString());


        UserService userService = new UserService();
    restarUserMenu:
        Console.WriteLine("----- User Menu -----");
        Console.Write("[1]Create user\n" +
            "[2] Create category\n" +
            "[3] User Login\n" +
            "[0] Exit\n" +
            ">>>");
        string option = Console.ReadLine();

        switch (option)
        {
            case "1":
                AddUser(userService);
                break;
            case "2":
                Console.Write("Category: ");
                string categoryName = Console.ReadLine();
                Category category = new Category(categoryName);
                userService.CreateCategory(category);
                break;
            case "3":
                Console.WriteLine("----- Login Process -----");
                Console.Write("Email: ");
                string email = Console.ReadLine();
                Console.Write("Password: ");
                string password = Console.ReadLine();

                try
                {
                    User myUser = userService.Login(email, password);

                    Console.WriteLine($"Welcome, {myUser.Fullname}!");
                    Console.WriteLine("----- Medicine service Menu -----");




                }
                catch (NotFoundException ex)
                {
                    Console.WriteLine("Error: {0}", ex.Message);
                }

                break;
            case "0":
                return;
            default:
                Console.WriteLine("Please enter valid option");
                break;

        }
        goto restarUserMenu;

    }

    private static void AddUser(UserService userService)
    {
        Console.Write("Fullname: ");
        string userName = Console.ReadLine();
        Console.Write("Email: ");
        string userEmail = Console.ReadLine();
        Console.Write("Email: ");
        string userPassword = Console.ReadLine();

        try
        {
            User user = new User(userName, userEmail, userPassword);
            userService.AddUser(user);

        }
        catch (NotFoundException ex)
        {
            Console.WriteLine("Error: {0}", ex.Message);
        }

    }
}
