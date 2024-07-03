namespace MedicalApp.Exceptions;

public class WrongEmailException : Exception
{
    public WrongEmailException(string message) : base(message)
    {
        
    }
}
