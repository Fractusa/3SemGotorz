using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gotorz.Models
{
    public class TravelPackage
    {
        [Key]
        public int Id { get; set; }

        public string DepartureFlightId { get; set; }
        public string ReturnFlightId { get; set; }
        public string HotelId { get; set; }

        public string Origin { get; set; }
        public string Destination { get; set; }
        public DateTime DepartureDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public int Adults { get; set; }

        public decimal DeparturePriceAtCreation { get; set; }
        public decimal ReturnPriceAtCreation { get; set; }
        public decimal HotelPriceAtCreation { get; set; }
        public DateTime CreationDate { get; set; }

        [NotMapped]
        public decimal TotalPrice => DeparturePriceAtCreation + ReturnPriceAtCreation + HotelPriceAtCreation;
    }
}
