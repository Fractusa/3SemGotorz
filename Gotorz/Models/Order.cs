namespace Gotorz.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string CustomerEmail { get; set; }
        public DateTime OrderDate { get; set; }
        public string Destination { get; set; } //Change to packet once packet is done
        public int Price { get; set; }
        public string Status { get; set; } // Completed, cancelled, etc 
    }
}
