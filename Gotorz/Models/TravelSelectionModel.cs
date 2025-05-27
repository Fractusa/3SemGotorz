using System.ComponentModel.DataAnnotations;

namespace Gotorz.Models
{
    public class TravelSelectionModel
    {

        public int TravelPackageId { get; set; }

        [Required]
        public DateTime DepartureDate { get; set; }
        [Required]
        public DateTime ReturnDate { get; set; }
        [Range(1, 5)]
        public int Adults { get; set; }
    }
}
