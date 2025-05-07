using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using GotorzAPI.Models;
using GotorzAPI.Services;

namespace GotorzAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : Controller
    {
        private AmadeusService _amadeusService;

        public HotelController(AmadeusService amadeusService)
        {
            _amadeusService = amadeusService;
        }

        [HttpGet]
        public async Task<IActionResult> GetHotels(string city, string checkIn, string checkOut, int adults)
        {
            var hotelIds = await _amadeusService.GetHotelIdsByCityCodeAsync(city);

            if (hotelIds.Count == 0)
                return NotFound($"No hotels found in {city}");

            var offers = await _amadeusService.SearchHotelsAsync(hotelIds, checkIn, checkOut, adults);

            return offers.Any() ? Ok(offers) : NotFound("No offers available");
        }
    }
}
