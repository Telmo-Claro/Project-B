using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace ProgramTest
{
    [TestClass]
    public class FlightDataRWTests
    {
        [TestMethod]
        public void TestReadJson()
        {
            // Arrange
            List<Flight> FlightData = new List<Flight>
            {
                new Flight
                {
                    FlightNumber = "TREN0001",
                    Departure = "Rotterdam",
                    Destination = "Wronie",
                    Date = DateTime.Now,
                    TimeDeparture = new TimeSpan(6,0,0),
                    TimeArrival = new TimeSpan(7,0,0),
                    Duration = new TimeSpan(1,0,0),
                    SelectedTimeslots = [],
                    Country = "Poland",
                    Aircraft = new Boeing787(),
                    Status = "Planned", Price = 50
                },
                new Flight
                {
                    FlightNumber = "TREN0002", 
                    Departure = "Rotterdam", 
                    Destination = "Lisbon", 
                    Date = DateTime.Now, 
                    TimeDeparture = new TimeSpan(6,0,0), 
                    TimeArrival = new TimeSpan(7,0,0),
                    Duration = new TimeSpan(1,0,0),
                    SelectedTimeslots = [],
                    Country = "Portugal",Aircraft = new Boeing787(), 
                    Status = "Planned", Price = 50
                }
            };
            Directory.CreateDirectory("DataBases");
            string jsonString = JsonSerializer.Serialize(FlightData);
            File.WriteAllText(Path.Combine("DataBases", "Flights.json"), jsonString);

            // Act
            List<Flight> flights = FlightDataRW.ReadJson();
            File.Delete(Path.Combine("DataBases", "Flights.json"));

            // Assert
            Assert.AreEqual(2, flights.Count);
            Assert.AreEqual("TREN0001", flights[0].FlightNumber);
            Assert.AreEqual("Lisbon", flights[1].Destination);
        }

        [TestMethod]
        public void TestWriteJson()
        {
            // Arrange
            List<Flight> FlightData = new List<Flight>
            {
                new Flight
                {
                    FlightNumber = "TREN0001",
                    Departure = "Rotterdam",
                    Destination = "Wronie",
                    Date = DateTime.Now,
                    TimeDeparture = new TimeSpan(6,0,0),
                    TimeArrival = new TimeSpan(7,0,0),
                    Duration = new TimeSpan(1,0,0),
                    SelectedTimeslots = [],
                    Country = "Poland",
                    Aircraft = new Boeing787(),
                    Status = "Planned", Price = 50
                },
                new Flight
                {
                    FlightNumber = "TREN0002", 
                    Departure = "Rotterdam", 
                    Destination = "Lisbon", 
                    Date = DateTime.Now, 
                    TimeDeparture = new TimeSpan(6,0,0), 
                    TimeArrival = new TimeSpan(7,0,0),
                    Duration = new TimeSpan(1,0,0),
                    SelectedTimeslots = [],
                    Country = "Portugal",Aircraft = new Boeing787(), 
                    Status = "Planned", Price = 50
                }
            };

            // Act
            Directory.CreateDirectory("DataBases");
            FlightDataRW.WriteJson(FlightData);
            string jsonString = File.ReadAllText(Path.Combine("DataBases", "Flights.json"));
            List<Flight>? Flights = JsonSerializer.Deserialize<List<Flight>>(jsonString);
            File.Delete(Path.Combine("DataBases", "Flights.json"));

            // Assert
            Assert.AreEqual(2, Flights.Count);
            Assert.AreEqual("TREN0001", Flights[0].FlightNumber);
            Assert.AreEqual("Lisbon", Flights[1].Destination);
        }
    }

    [TestClass]
    public class PageScrollerTests
    {
        [TestMethod]
        [DataRow(ConsoleKey.LeftArrow, 2, 1)]
        [DataRow(ConsoleKey.RightArrow, 1, 2)]
        [DataRow(ConsoleKey.LeftArrow, 1, 1)]
        public void TestNextPage(ConsoleKey key, int page, int expected)
        {
            //Arrange
            //Act
            int actual = PageScroller.NextPage(key, page);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
    
    [TestClass]
    public class AccountCreation
    {
        [TestMethod]
        public void FirstNameTest_Correct()
        {
            //Arrange
            string firstName = "John";
            //Act
            bool isValid = ValidateAccountInformation.ValidateFirstName(firstName);

            // Assert
            Assert.AreEqual(true, isValid);
        }
        
        [TestMethod]
        public void FirstNameTest_Incorrect()
        {
            //Arrange
            string firstName = "John0";
            //Act
            bool isValid = ValidateAccountInformation.ValidateFirstName(firstName);

            // Assert
            Assert.AreEqual(false, isValid);
        }
        
        [TestMethod]
        public void LastNameTest_Correct()
        {
            //Arrange
            string lastName = "Doe";
            
            //Act
            bool isValid = ValidateAccountInformation.ValidateLastName(lastName);

            // Assert
            Assert.AreEqual(true, isValid);
        }
        
        [TestMethod]
        public void LastNameTest_Incorrect()
        {
            //Arrange
            string lastName = "Doe0";
            
            //Act
            bool isValid = ValidateAccountInformation.ValidateLastName(lastName);

            // Assert
            Assert.AreEqual(false, isValid);
        }
        
        [TestMethod]
        public void EmailTest_Correct()
        {
            //Arrange
            string email = "johndoe@gmail.com";
            
            //Act
            bool isValid = ValidateAccountInformation.ValidateEmail(email);

            // Assert
            Assert.AreEqual(true, isValid);
        }
        
        [TestMethod]
        public void EmailTest_Incorrect()
        {
            //Arrange
            string email = "johndoegmail.com";
            
            //Act
            bool isValid = ValidateAccountInformation.ValidateEmail(email);

            // Assert
            Assert.AreEqual(false, isValid);
        }
        
        [TestMethod]
        public void PasswordTest_Correct()
        {
            //Arrange
            string password = "123456789";
            
            //Act
            bool isValid = ValidateAccountInformation.ValidatePassword(password);

            // Assert
            Assert.AreEqual(true, isValid);
        }
        
        [TestMethod]
        public void PasswordTest_Incorrect()
        {
            //Arrange
            string password = "123";
            
            //Act
            bool isValid = ValidateAccountInformation.ValidatePassword(password);

            // Assert
            Assert.AreEqual(false, isValid);
        }
        
        [TestMethod]
        public void PhoneNumberTest_Correct()
        {
            //Arrange
            string phonenumber = "0612345678";
            
            //Act
            bool isValid = ValidateAccountInformation.ValidatePhoneNumber(phonenumber);

            // Assert
            Assert.AreEqual(true, isValid);
        }
        
        [TestMethod]
        public void PhoneNumberTest_Incorrect()
        {
            //Arrange
            string phonenumber = "061";
            
            //Act
            bool isValid = ValidateAccountInformation.ValidatePhoneNumber(phonenumber);

            // Assert
            Assert.AreEqual(false, isValid);
        }

    }
}
