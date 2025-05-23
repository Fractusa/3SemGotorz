namespace Gotorz.Models
{
    public class TravelPackage
    {
        public FlightData DepartureFlight { get; set; }
        public FlightData ReturnFlight { get; set; }
        public HotelData Hotel { get; set; }

        public decimal TotalPrice => DepartureFlight.Price + ReturnFlight.Price + Hotel.Price;
    }
}
