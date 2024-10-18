public class Account
{
    public int id;
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Password { get; set; }

    public Account(string firstname, string lastname, string email, string phonenumber, string password)
    {
        this.FirstName = firstname;
        this.LastName = lastname;
        this.Email = email;
        this.PhoneNumber = phonenumber;
        this.Password = password;
    }
}