using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Gotorz.Models;

namespace Gotorz.Controllers
{
    public class FlightsandHotelsOverviewController : Controller
    {
        public async Task<IActionResult> DisplayOriginFlights(string origin, string destination, string departureDate)
        {
            Flight flight = new Flight
            {
                Origin = origin,
                Destination = destination,
                DepartureDate = departureDate,
                Flights = new List<Flight>()
            };

            string departureApiUrl = $"http://localhost:6000/api/flight?origin={origin}&destination={destination}&date={departureDate}";

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage originResponse = await client.GetAsync(departureApiUrl);

                if (originResponse.IsSuccessStatusCode)
                {
                    var json = await originResponse.Content.ReadAsStringAsync();
                    flight.Flights = JsonConvert.DeserializeObject<List<Flight>>(json);                   
                }
            }

            return View(flight);
        }

        public async Task<IActionResult> DisplayReturnFlights(string origin, string destination, string returnDate)
        {
            if (string.IsNullOrEmpty(origin))
            {
                ViewBag.Error = "Please enter a city";
                return View();
            }

            ViewBag.Origin = origin;

            string returnApiUrl = $"http://localhost:6000/api/flight?origin={origin}&destination={destination}&date={returnDate}";

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage returnResponse = await client.GetAsync(returnApiUrl);

                if (returnResponse.IsSuccessStatusCode) 
                {
                    var json = await returnResponse.Content.ReadAsStringAsync();
                    var flights = JsonConvert.DeserializeObject<List<Flight>>(json);
                    ViewBag.ReturnFlight = flights;
                }
            }

            return View();
        }

        public async Task<IActionResult> DisplayHotels()
        {
            return View();
        }
    }
}
