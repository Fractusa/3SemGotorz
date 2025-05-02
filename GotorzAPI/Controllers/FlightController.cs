using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using GotorzAPI.Models;
using GotorzAPI.Services;
//using System.Web.Http;

namespace GotorzAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightController : Controller
    {
        private AmadeusService _amadeusService;

        public FlightController(AmadeusService amadeusService)
        {
            _amadeusService = amadeusService;
        }

        [HttpGet]
        public async Task<IActionResult> GetFlights(string origin, string destination, string date)
        {
            var flights = await _amadeusService.SearchFlightsAsync(origin, destination, date);

            if (flights == null || flights.Count == 0)
                return NotFound("No flights found.");

            return Ok(flights);
        }
    }
}
