using System;
using System.Runtime.CompilerServices;
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
                new Flight { FlightNumber = "TREN0001", Departure = "Rotterdam", Destination = "Wronie", Date = DateTime.Now, TimeDeparture = new TimeSpan(6,0,0), TimeArrival = new TimeSpan(7,0,0), Duration = new TimeSpan(1,0,0), Country = "Poland", Aircraft = new Boeing787(), Status = "Planned", Price = 50 },
                new Flight { FlightNumber = "TREN0002", Departure = "Rotterdam", Destination = "Lisbon", Date = DateTime.Now, TimeDeparture = new TimeSpan(6,0,0), TimeArrival = new TimeSpan(7,0,0), Duration = new TimeSpan(1,0,0), Country = "Portugal",Aircraft = new Boeing787(), Status = "Planned", Price = 50 }
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
                new Flight { FlightNumber = "TREN0001", Departure = "Rotterdam", Destination = "Wronie", Date = DateTime.Now, TimeDeparture = new TimeSpan(6,0,0), TimeArrival = new TimeSpan(7,0,0), Duration = new TimeSpan(1,0,0), Country = "Poland", Aircraft = new Boeing787(), Status = "Planned", Price = 50 },
                new Flight { FlightNumber = "TREN0002", Departure = "Rotterdam", Destination = "Lisbon", Date = DateTime.Now, TimeDeparture = new TimeSpan(6,0,0), TimeArrival = new TimeSpan(7,0,0), Duration = new TimeSpan(1,0,0), Country = "Portugal", Aircraft = new Boeing787(), Status = "Planned", Price = 50 }
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
}
