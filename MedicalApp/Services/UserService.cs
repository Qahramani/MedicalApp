using MedicalApp.Exceptions;
using MedicalApp.Models;
using MedicalApp.Utilities;

namespace MedicalApp.Services;

public class UserService
{
    public User Login(string email, string password)
    {
        
        foreach (var user in DB.users)
        {
            if(user.Password == password && user.Email.ToLower() == email.ToLower())
                return user;
        }

        throw new UserNotFoundException("User not found");
    }

    public void AddUser(User user)
    {
        foreach (var usr in DB.users)
        {
            if(usr.Email.ToLower() == user.Email.ToLower())
            {
                throw new UserAlreadyExistException("User with given Email is already exist");
            }
        }
        Array.Resize(ref DB.users, DB.users.Length + 1);
        DB.users[^1] = user;
        Colored.WriteLine("User succesfully created!", ConsoleColor.Green);
    }


}
