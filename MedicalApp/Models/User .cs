namespace MedicalApp.Models;

public class User : BaseEntity
{
    private static int _id;
    public string Fullname { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

    public User(string fullname, string email, string password)
    {
        Fullname = fullname;
        Email = email;
        Password = password;
        Id = _id++;
    }
    public override string ToString()
    {
        return $"User Name: {Fullname}, Email: {Email}, Id: {Id}";
    }

}
