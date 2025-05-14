namespace Gotorz.Models
{
    public class TravelData
    {
        public List<FlightData> OutboundFlights { get; set; } = new();
        public List<FlightData> ReturnFlights { get; set; } = new();
        public List<HotelData> Hotels { get; set; } = new();
    }
}
