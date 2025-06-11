namespace GotorzAPI.Models
{
    public class HotelData
    {
        public string HotelName { get; set; } = string.Empty;
        public string HotelId { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Currency { get; set; } = string.Empty;
        public string CheckIn { get; set; } = string.Empty;
        public string CheckOut { get; set; } = string.Empty;
    }
}
