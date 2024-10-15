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
                new Flight { FlightNumber = "TREN0001", Departure = "Rotterdam", Destination = "Wronie", TimeDeparture = null, TimeArrival = null, Duration = 8.0, Aircraft = new Boeing787() },
                new Flight { FlightNumber = "TREN0002", Departure = "Rotterdam", Destination = "Lisbon", TimeDeparture = null, TimeArrival = null, Duration = 8.0, Aircraft = new Boeing787() }
            };
            Directory.CreateDirectory("DataBases");
            string jsonString = JsonSerializer.Serialize(FlightData);
            File.WriteAllText("DataBases\\Flights.json", jsonString);

            // Act
            List<Flight> flights = FlightDataRW.ReadJson();
            File.Delete("DataBases\\Flights.json");

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
                new Flight { FlightNumber = "TREN0001", Departure = "Rotterdam", Destination = "Wronie", TimeDeparture = null, TimeArrival = null, Duration = 8.0, Aircraft = new Boeing787() },
                new Flight { FlightNumber = "TREN0002", Departure = "Rotterdam", Destination = "Lisbon", TimeDeparture = null, TimeArrival = null, Duration = 8.0, Aircraft = new Boeing787() }
            };

            // Act
            Directory.CreateDirectory("DataBases");
            FlightDataRW.WriteJson(FlightData);
            string jsonString = File.ReadAllText("DataBases\\Flights.json");
            List<Flight>? Flights = JsonSerializer.Deserialize<List<Flight>>(jsonString);
            File.Delete("DataBases\\Flights.json");

            // Assert
            Assert.AreEqual(2, Flights.Count);
            Assert.AreEqual("TREN0001", Flights[0].FlightNumber);
            Assert.AreEqual("Lisbon", Flights[1].Destination);
        }
    }
}
