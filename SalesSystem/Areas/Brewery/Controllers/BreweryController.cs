using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Zythum.Areas.Brewery.Controllers
{
   // [Authorize]
    [Area("Brewery")]
    public class BreweryController : Controller
    {
        public IActionResult Brewery()
        {
            return View();
        }
    }
}
