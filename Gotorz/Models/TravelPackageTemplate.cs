using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gotorz.Models
{
    public class TravelPackageTemplate
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Origin { get; set; }

        [Required]
        public string Destination { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string HotelId { get; set; }

        [NotMapped]
        public HotelData? Hotel { get; set; }
    }
}
