using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using GotorzAPI.Models;
//using System.Web.Http;

namespace GotorzAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("flights/{city}")]
        public async Task<IActionResult> GetFlights(string city)
        {
            string apiKey = "HHgMzxzswzCmOEQNl9Qa9nnB6JIEFeuG";
            string apiUrl = $"test.api.amadeus.com";

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode) 
                {
                    string json = await response.Content.ReadAsStringAsync();

                    var flights = JsonConvert.DeserializeObject<FlightData>(json);

                    
                }

                return BadRequest("Error when finding flights");
            }
        }
    }
}
