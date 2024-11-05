public interface IPay
{
    string FirstName { get; set; }
    string LastName { get; set; }
    string Number { get; set; }
    string IDealURL { get; set; }

    public void Pay();
}