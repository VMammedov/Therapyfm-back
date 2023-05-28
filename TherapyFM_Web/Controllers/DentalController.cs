using Microsoft.AspNetCore.Mvc;

namespace TherapyFM_Web.Controllers
{
    public class DentalController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
