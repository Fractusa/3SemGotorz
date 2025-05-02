using GotorzAPI.Models;
using Microsoft.AspNetCore.Authentication.OAuth;
using Newtonsoft.Json;
using GotorzAPI.Models;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace GotorzAPI.Services
{
    public class AmadeusService
    {
        private HttpClient _httpClient;
        private string accessToken;

        public AmadeusService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task AuthenticateAsync()
        {
            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("grant_type", "client_credentials"),
                new KeyValuePair<string, string>("client_id", "HHgMzxzswzCmOEQNl9Qa9nnB6JIEFeuG"),
                new KeyValuePair<string, string>("client_secret", "FXIttmBlzdy91nGO")
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

        public class AuthResponse
        {
            [JsonPropertyName("access_token")]
            public string AccessToken { get; set; }
        }
    }
}
