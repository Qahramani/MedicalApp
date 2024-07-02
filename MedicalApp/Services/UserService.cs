using MedicalApp.Exceptions;
using MedicalApp.Models;

namespace MedicalApp.Services;

public class UserService
{
    public User Login(string email, string password)
    {
        foreach (var user in DB.users)
        {
            if(user.Password == password && user.Email == email)
                return user;
        }

        throw new NotFoundException("User not found");
    }

    public void AddUser(User user)
    {
        foreach (var usr in DB.users)
        {
            if(usr.Email == user.Email)
            {
                throw new NotFoundException("User with given Email is already exist");
            }
        }
        Array.Resize(ref DB.users, DB.users.Length + 1);
        DB.users[^1] = user;
        Console.WriteLine("User succesfully Added");
    }

    public void CreateCategory(Category category)
    {
        Array.Resize(ref DB.categories, DB.categories.Length + 1);
        DB.categories[^1] = category;
    }
}
