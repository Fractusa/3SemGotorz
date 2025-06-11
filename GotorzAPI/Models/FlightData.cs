namespace GotorzAPI.Models
{
    public class FlightData
    {
        public string FlightId { get; set; } = string.Empty;

        public string DepartureAirport { get; set; } = string.Empty;

        public string ArrivalAirport { get; set; } = string.Empty;

        public DateTime DepartureTime { get; set; }

        public DateTime ArrivalTime { get; set; }

        public decimal Price { get; set; }

        public string Currency { get; set; } = string.Empty;
    }
}
