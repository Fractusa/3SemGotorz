namespace Gotorz.Models
{
    public class Flight
    {
        public string Origin { get; set; }
        public string Destination { get; set; }
        public string DepartureDate { get; set; }
        public List<Flight> Flights { get; set; }
    }
}
