public class Account
{
    public int id;
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Password { get; set; }
    public List<Flight> bookedFlights { get; set; }
    public Account(string firstname, string lastname, string email, string phonenumber, string password)
    {
        this.FirstName = firstname;
        this.LastName = lastname;
        this.Email = email;
        this.PhoneNumber = phonenumber;
        this.Password = password;
        this.bookedFlights = [
            new Flight { FlightNumber = "TREN0001", Departure = "Rotterdam", Destination = "Wronie", Date = DateTime.Now, TimeDeparture = new TimeSpan(6,0,0), TimeArrival = new TimeSpan(7,0,0), Duration = new TimeSpan(1,0,0), Country = "Poland", Aircraft = new Boeing787(), Status = "Planned" },
            new Flight { FlightNumber = "TREN0002", Departure = "Rotterdam", Destination = "Lisbon", Date = DateTime.Now, TimeDeparture = new TimeSpan(6,0,0), TimeArrival = new TimeSpan(7,0,0), Duration = new TimeSpan(1,0,0), Country = "Portugal", Aircraft = new Boeing787(), Status = "Planned" }
        ];
    }
}