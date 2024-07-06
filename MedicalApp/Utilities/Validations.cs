using MedicalApp.Exceptions;

namespace MedicalApp.Utilities;

public static class Validations
{
    public static void IsPasswordCorrect(string password)
    {
        bool isUpper = false;
        bool isLower = false;
        bool isDigit = false;
        for (int i = 0; i < password.Length; i++)
        {
            if (char.IsUpper(password[i]))
            isUpper = true;
            else if (char.IsLower(password[i]))
                isLower = true;
            else if (char.IsDigit(password[i]))
                isDigit = true;
            if(isUpper && isLower && isDigit && password.Length >= 5)
                return;
        }
        
        throw new WrongPasswordException("Password should contain lower and upper letters, digit and length should be >= 5");
    }

    public static void IsEmailCorrect(string email)
    {
        if (email.Length < 6)
            throw new WrongEmailException("email length should be at least 6 characters");
        int counter = 0;
        for (int i = 0; i < email.Length; i++)
        {
            if (email[i] == '@')
            {
                counter++;
            }
            else if(!char.IsLetter(email[i]) && !char.IsDigit(email[i]) && !(email[i] == '.'))
            {
                throw new WrongEmailException("email can contain only letters, numbers, underscore, dot and one @ tag");
            }
        }
        if (counter != 1)
            throw new WrongEmailException("email should contain 1 @ tag");
    }
}
