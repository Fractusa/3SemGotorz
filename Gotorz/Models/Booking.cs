using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gotorz.Models
{
    public class Booking
    {
        [Key]
        public int Id { get; set; }

        public string DepartureFlightId { get; set; }
        public string ReturnFlightId { get; set; }
        public string HotelId { get; set; }
        public string HotelName { get; set; }
        public DateTime HotelCheckIn {  get; set; }
        public DateTime HotelCheckOut { get; set; }
        public string UserEmail { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public int Adults { get; set; }
        public DateTime TakeoffTimeDepartureFlight { get; set; }
        public DateTime LandingTimeDepartureFlight { get; set; }
        public DateTime TakeoffTimeReturnFlight { get; set; }
        public DateTime LandingTimeReturnFlight { get; set; }
        public DateTime CreationDate { get; set; }

        public decimal DeparturePriceAtCreation { get; set; }
        public decimal ReturnPriceAtCreation { get; set; }
        public decimal HotelPriceAtCreation { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
