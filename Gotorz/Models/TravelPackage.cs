using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gotorz.Models
{
    public class TravelPackage
    {
        [Key]
        public int Id { get; set; }

        public string Origin {  get; set; }
        public string Destination { get; set; }

        public string HotelName {  get; set; }
        public string HotelId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
