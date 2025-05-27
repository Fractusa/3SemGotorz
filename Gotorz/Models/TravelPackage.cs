using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gotorz.Models
{
    public class TravelPackage
    {
        [Key]
        public int Id { get; set; }

        public FlightData DepartureFlight { get; set; }
        public FlightData ReturnFlight { get; set; }
        public HotelData Hotel { get; set; }

        public decimal TotalPrice => DepartureFlight.Price + ReturnFlight.Price + Hotel.Price;
    }
}
