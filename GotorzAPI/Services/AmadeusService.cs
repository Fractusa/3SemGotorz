using GotorzAPI.Models;
using Microsoft.AspNetCore.Authentication.OAuth;
using Newtonsoft.Json;
using GotorzAPI.Models;
using System.Text.Json.Serialization;
using System.Text.Json;
using Microsoft.Extensions.Options;
using System;
using System.Diagnostics;

namespace GotorzAPI.Services
{
    public class AmadeusService
    {
        private HttpClient _httpClient;
        private string accessToken;
        private readonly string _apiKey;
        private readonly string _apiSecret;

        public AmadeusService(HttpClient httpClient, IOptions<AmadeusSettings> config)
        {
            _httpClient = httpClient;
            _apiKey = config.Value.ClientId;
            _apiSecret = config.Value.ClientSecret;
        }

        public async Task AuthenticateAsync()
        {
            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("grant_type", "client_credentials"),
                new KeyValuePair<string, string>("client_id", _apiKey),
                new KeyValuePair<string, string>("client_secret", _apiSecret)
            });

            var response = await _httpClient.PostAsync("https://test.api.amadeus.com/v1/security/oauth2/token", content);

            if (response.IsSuccessStatusCode)
            {
                var authResult = await response.Content.ReadFromJsonAsync<AuthResponse>();

                accessToken = authResult.AccessToken;
            }
        }

        public async Task<List<FlightData>> SearchFlightsAsync(string origin, string destination, string date)
        {
            if (string.IsNullOrEmpty(accessToken))
            {
                await AuthenticateAsync();
            }

            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);

            var response = await _httpClient.GetAsync($"https://test.api.amadeus.com/v2/shopping/flight-offers?originLocationCode={origin}&destinationLocationCode={destination}&departureDate={date}&adults=1&max=5");

            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                var jsonDoc = JsonDocument.Parse(json);

                var flights = new List<FlightData>();

                foreach (var flight in jsonDoc.RootElement.GetProperty("data").EnumerateArray())
                {
                    var firstItinerary = flight.GetProperty("itineraries")[0];
                    var firstSegment = firstItinerary.GetProperty("segments")[0];

                    flights.Add(new FlightData
                    {
                        FlightId = flight.GetProperty("id").GetString(),
                        DepartureAirport = firstSegment.GetProperty("departure").GetProperty("iataCode").GetString(),
                        ArrivalAirport = firstSegment.GetProperty("arrival").GetProperty("iataCode").GetString(),
                        DepartureTime = DateTime.Parse(firstSegment.GetProperty("departure").GetProperty("at").GetString()),
                        ArrivalTime = DateTime.Parse(firstSegment.GetProperty("arrival").GetProperty("at").GetString()),
                        Price = decimal.Parse(flight.GetProperty("price").GetProperty("total").GetString())
                    });
                }

                return flights;
            }

            return new List<FlightData>();
        }

        public async Task<List<string>> GetHotelIdsByCityCodeAsync(string cityCode)
        {
            if (string.IsNullOrEmpty(accessToken))
                await AuthenticateAsync();

            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);

            var response = await _httpClient.GetAsync($"https://test.api.amadeus.com/v1/reference-data/locations/hotels/by-city?cityCode={cityCode}");

            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                var jsonDoc = JsonDocument.Parse(json);

                return jsonDoc.RootElement.GetProperty("data").EnumerateArray().Select(x => x.GetProperty("hotelId").GetString()).ToList();
            }

            return null;
        }

        public async Task<List<HotelData>> SearchHotelsAsync(List<string> hotelIds, string checkIn, string checkOut, int adults)
        {
            if (string.IsNullOrEmpty(accessToken))
                await AuthenticateAsync();

            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);

            var hotelIdsJoined = string.Join(",", hotelIds.Take(20));
            var response = await _httpClient.GetAsync($"https://test.api.amadeus.com/v2/shopping/hotel-offers?hotelIds={hotelIdsJoined}&checkInDate={checkIn}&checkOutDate={checkOut}&adults={adults}");
            string json = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {              
                var jsonDoc = JsonDocument.Parse(json);

                var hotels = new List<HotelData>();

                foreach (var item in jsonDoc.RootElement.GetProperty("data").EnumerateArray())
                {
                    var hotel = item.GetProperty("hotel");
                    var offer = item.GetProperty("offers")[0];

                    hotels.Add(new HotelData
                    {
                        HotelName = hotel.GetProperty("name").GetString(),
                        HotelId = hotel.GetProperty("hotelId").GetString(),
                        Price = decimal.Parse(offer.GetProperty("price").GetProperty("total").GetString()),
                        CheckIn = checkIn,
                        CheckOut = checkOut
                    });
                }

                return hotels;
            }

            if (!response.IsSuccessStatusCode)
            {
                Trace.WriteLine($"Hotel offer API failed: {response.StatusCode}");
                Trace.WriteLine($"Response content: {json}");
                Console.WriteLine($"Hotel offer API failed: {response.StatusCode}");
                Console.WriteLine($"Response content: {json}");
                return new List<HotelData>(); // Exit early on error
            }

            return new List<HotelData>();
        }

        public class AuthResponse
        {
            [JsonPropertyName("access_token")]
            public string AccessToken { get; set; }
        }
    }
}
