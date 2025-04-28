using Microsoft.AspNetCore.Mvc;

namespace GotorzAPI.Controllers
{
    public class HotelController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
