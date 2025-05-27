namespace Gotorz.Models
{
    public class FlightData
    {
        public string FlightId { get; set; }

        public string DepartureAirport { get; set; }

        public string ArrivalAirport { get; set; }

        public DateTime DepartureTime { get; set; }

        public DateTime ArrivalTime { get; set; }

        public decimal Price { get; set; }
    }
}
