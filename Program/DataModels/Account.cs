public class Account
{
    public int Id;
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Password { get; set; }
    public Payment PaymentMethod { get; set; }
    public List<Flight> BookedFlights { get; set; }
    public Account(string? firstname, string? lastname, string? email, string? phonenumber, string? password, Payment paymentMethod)
    {
        this.FirstName = firstname;
        this.LastName = lastname;
        this.Email = email;
        this.PhoneNumber = phonenumber;
        this.Password = password;
        this.PaymentMethod = paymentMethod;
        this.BookedFlights = [
            new Flight { FlightNumber = "TREN0001", Departure = "Rotterdam", Destination = "Wronie", Date = DateTime.Now, TimeDeparture = new TimeSpan(6,0,0), TimeArrival = new TimeSpan(7,0,0), Duration = new TimeSpan(1,0,0), Country = "Poland", Aircraft = new Boeing787(), Status = "Planned" },
            new Flight { FlightNumber = "TREN0002", Departure = "Rotterdam", Destination = "Lisbon", Date = DateTime.Now, TimeDeparture = new TimeSpan(6,0,0), TimeArrival = new TimeSpan(7,0,0), Duration = new TimeSpan(1,0,0), Country = "Portugal", Aircraft = new Boeing787(), Status = "Planned" }
        ];
    }
}