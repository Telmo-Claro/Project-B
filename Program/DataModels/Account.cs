using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

public class Account
{
    public int Id { get; set; }

    [JsonPropertyName("FirstName")]
    public string? FirstName { get; set; }

    [JsonPropertyName("LastName")]
    public string? LastName { get; set; }

    [JsonPropertyName("Email")]
    public string? Email { get; set; }

    [JsonPropertyName("PhoneNumber")]
    public string? PhoneNumber { get; set; }

    [JsonPropertyName("Password")]
    public string? Password { get; set; }

    [JsonPropertyName("CreditCardInfo")]
    public Payment? CreditCardInfo { get; set; }

    [JsonPropertyName("BookedFlights")]
    public List<Flight> BookedFlights { get; set; }

    [JsonPropertyName("BookingCodes")]
    public List<string> BookingCodes { get; set; }

    public Account(string? firstName, string? lastName, string? email, string? phoneNumber, string? password, Payment? creditCardInfo = null)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        PhoneNumber = phoneNumber;
        Password = password;
        CreditCardInfo = creditCardInfo;
        BookedFlights = new List<Flight>();
        BookingCodes = new List<string>();
    }
}
