using Microsoft.AspNetCore.Mvc;

namespace TherapyFM_Web.Controllers
{
    public class AestheticController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
