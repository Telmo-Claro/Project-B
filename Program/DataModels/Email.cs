using System;
using System.Net;
using System.Net.Mail;
public class Email
{
    public static void SendEmail(Account account)
    {
        string fromMail = "trenlines010@gmail.com";
        string fromPassword = "wcmt inui pwzm ymvh";

        MailMessage message = new MailMessage();
        message.From = new MailAddress(fromMail);
        message.Subject = "Your Flight Booking Confirmation";
        message.To.Add(new MailAddress(account.Email));

        // HTML body for the flight booking confirmation email
        message.Body = @$"
            <html>
            <body style='font-family: Arial, sans-serif; color: #333; line-height: 1.6;'>
                <div style='max-width: 600px; margin: auto; border: 1px solid #ddd; border-radius: 8px; overflow: hidden;'>
                    <div style='background-color: #004080; color: white; padding: 20px; text-align: center;'>
                        <h1 style='margin: 0; font-size: 24px;'>Flight Booking Confirmation</h1>
                    </div>
                    <div style='padding: 20px; background-color: #f9f9f9;'>
                        <h2 style='font-size: 20px;'>Hello, {account.FirstName}</h2>
                        <p>Thank you for booking with TrenLines! Here are the details of your upcoming flight:</p>
                        <table style='width: 100%; border-collapse: collapse; margin-top: 10px;'>
                            <tr>
                                <th style='text-align: left; padding: 8px; background-color: #004080; color: white;'>Flight</th>
                                <td style='padding: 8px;'>{{FlightNumber}}</td>
                            </tr>
                            <tr>
                                <th style='text-align: left; padding: 8px; background-color: #f1f1f1;'>Departure</th>
                                <td style='padding: 8px;'>{{DepartureCity}} - {{DepartureTime}}</td>
                            </tr>
                            <tr>
                                <th style='text-align: left; padding: 8px; background-color: #f1f1f1;'>Arrival</th>
                                <td style='padding: 8px;'>{{ArrivalCity}} - {{ArrivalTime}}</td>
                            </tr>
                            <tr>
                                <th style='text-align: left; padding: 8px; background-color: #004080; color: white;'>Seat</th>
                                <td style='padding: 8px;'>{{SeatNumber}}</td>
                            </tr>
                        </table>
                        <p style='margin-top: 20px;'>If you have any questions or need further assistance, feel free to reach out to our support team.</p>
                        <p>Wishing you a pleasant journey!</p>
                    </div>
                    <div style='background-color: #004080; color: white; text-align: center; padding: 10px; font-size: 12px;'>
                        &copy; 2023 TrenLines Inc. All rights reserved.
                    </div>
                </div>
            </body>
            </html>";

        message.IsBodyHtml = true;

        var smtpClient = new SmtpClient("smtp.gmail.com")
        {
            Port = 587,
            Credentials = new NetworkCredential(fromMail, fromPassword),
            EnableSsl = true,
        };

        smtpClient.Send(message);
    }
}