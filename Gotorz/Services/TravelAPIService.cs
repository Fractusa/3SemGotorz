using System.Net.Http.Json;
using Gotorz.Models;
using static System.Net.WebRequestMethods;

namespace Gotorz.Services
{
    public class TravelAPIService
    {
        private readonly HttpClient _httpClient;

        public TravelAPIService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<FlightData>> GetFlightsAsync(string origin, string destination, string date)
        {
            var url = $"http://localhost:5000/api/flight?origin={origin}&destination={destination}&date={date}";
            return await _httpClient.GetFromJsonAsync<List<FlightData>>(url) ?? new();
        }

        public async Task<List<HotelData>> GetHotelsAsync(string city, string checkIn, string checkOut, int adults)
        {
            var url = $"http://localhost:5000/api/hotel?city={city}&checkIn={checkIn}&checkOut={checkOut}&adults={adults}";
            return await _httpClient.GetFromJsonAsync<List<HotelData>>(url) ?? new();
        }
    }
}
